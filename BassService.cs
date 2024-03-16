﻿using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using Un4seen.Bass;

namespace ContinuousAudioOverlay
{
    public class BassService
    {
        private Assembly bassAssembly;
        private dynamic bassInstance;
        private dynamic previousTagInfo;
        static int _streamHandle;
        Type bassType;
        Type bassTagsType;
        List<Radio> radioList = new List<Radio>();
        private bool bassInitialized = false;

        public BassService()
        {

        }

        private void LoadBassAssembly()
        {
            try
            {
                string currentAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                DirectoryInfo solutionDirectory = Directory.GetParent(currentAssemblyDirectory)?.Parent?.Parent;

                if (solutionDirectory != null)
                {
                    string dllPath = Path.Combine(solutionDirectory.FullName, "Libraries", "Bass.Net.dll");
                    bassAssembly = Assembly.LoadFrom(dllPath);
                    if (bassAssembly != null)
                    {
                        var bassType = bassAssembly.GetType("Un4seen.Bass.Bass");
                        if(bassType != null)
                        {
                            bassInstance = Activator.CreateInstance(bassType);
                        }

                        dllPath = Path.Combine(solutionDirectory.FullName, "Libraries", "bass.dll");
                        bassTagsType = bassAssembly.GetType("Un4seen.Bass.AddOn.Tags.TAG_INFO");
                        if (bassTagsType != null)
                        {
                            previousTagInfo = Activator.CreateInstance(bassTagsType);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                bassAssembly = null;
                MessageBox.Show($"Failed to load BASS.NET library: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Radio> GetRadioList()
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RadioList.xml");
            XDocument doc;

            if (!File.Exists(xmlFilePath))
            {
                doc = new XDocument(
                    new XElement("Radios",
                        new XElement("Radio",
                            new XElement("RadioName", "Rádio Čas Rock"),
                            new XElement("RadioURL", "https://icecast9.play.cz/casrock192.mp3")
                        ),
                        new XElement("Radio",
                            new XElement("RadioName", "Rádio Kiss"),
                            new XElement("RadioURL", "http://icecast4.play.cz/kiss128.mp3")
                        )
                    )
                );
                doc.Save(xmlFilePath);
            }

            if (File.Exists(xmlFilePath))
            {
                doc = XDocument.Load(xmlFilePath);

                var radios = doc.Descendants("Radio")
                                .Select(radio => new Radio
                                {
                                    RadioName = radio.Element("RadioName")?.Value,
                                    RadioURL = radio.Element("RadioURL")?.Value
                                })
                                .ToList();
                radioList.AddRange(radios);
            }

            return radioList;
        }



        public void IndexChanged(int index)
        {
            if(!bassInitialized)
            {
                bassInitialized = true;
                LoadBassAssembly();
            }
            string radioURL = radioList[index].RadioURL;

            if (bassAssembly != null)
            {
                bassType = bassAssembly.GetType("Un4seen.Bass.Bass");

                MethodInfo bassInitMethod = bassType.GetMethod("BASS_Init");
                bool initSuccess = (bool)bassInitMethod.Invoke(null, new object[] { -1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero });

                if (!initSuccess)
                {
                    return;
                }

                MethodInfo bassStreamCreateURLMethod = bassType.GetMethod("BASS_StreamCreateURL");
                _streamHandle = (int)bassStreamCreateURLMethod.Invoke(null, new object[] { radioURL, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero });

                if (_streamHandle != 0)
                {
                    MethodInfo bassChannelPlayMethod = bassType.GetMethod("BASS_ChannelPlay");
                    bassChannelPlayMethod.Invoke(null, new object[] { _streamHandle, true });

                    Type[] parameterTypes = new Type[] { typeof(int), typeof(BASSAttribute), typeof(float) }; // Adjust the parameter types as necessary
                    MethodInfo bassChannelSetAttributeMethod = bassType.GetMethod("BASS_ChannelSetAttribute", parameterTypes);
                    bassChannelSetAttributeMethod.Invoke(null, new object[] { _streamHandle, BASSAttribute.BASS_ATTRIB_VOL, 0.1f });
                }
                else
                {
                    MessageBox.Show($"Radio could not be loaded.\r\nRadio URL: {radioURL}", "Error loading radio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("BASS library is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReleaseBassResources()
        {
            if (bassAssembly != null && bassType != null)
            {
                MethodInfo bassChannelStopMethod = bassType.GetMethod("BASS_ChannelStop");
                if (bassChannelStopMethod != null)
                {
                    bassChannelStopMethod.Invoke(null, new object[] { _streamHandle });
                }
                else
                {
                    MessageBox.Show("BASS_ChannelStop method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MethodInfo bassStreamFreeMethod = bassType.GetMethod("BASS_StreamFree");
                if (bassStreamFreeMethod != null)
                {
                    bassStreamFreeMethod.Invoke(null, new object[] { _streamHandle });
                }
                else
                {
                    MessageBox.Show("BASS_StreamFree method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MethodInfo bassFreeMethod = bassType.GetMethod("BASS_Free");
                if (bassFreeMethod != null)
                {
                    bassFreeMethod.Invoke(null, null);
                }
                else
                {
                    MessageBox.Show("BASS_Free method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("BASS library is not loaded or Bass type is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TagInfoPropertiesChanged(dynamic current, dynamic previous)
        {
            return current?.title != previous?.title;
        }

        public (string, string, bool) GetTitleTags()
        {
            string radioURL = "https://icecast9.play.cz/casrock192.mp3";

            if (bassAssembly != null)
            {
                dynamic tagInfo = Activator.CreateInstance(bassTagsType, radioURL);

                Type bassTagsTypeLocal = bassAssembly.GetType("Un4seen.Bass.AddOn.Tags.BassTags");
                MethodInfo getFromUrlMethod = bassTagsTypeLocal?.GetMethod("BASS_TAG_GetFromURL", new[] { typeof(int), bassTagsType });

                if (getFromUrlMethod != null)
                {
                    bool result = (bool)getFromUrlMethod.Invoke(null, new object[] { _streamHandle, tagInfo });

                    if (result && tagInfo.title != null && tagInfo.artist != null)
                    {
                        string title = WebUtility.HtmlDecode(tagInfo.title);
                        string artist = WebUtility.HtmlDecode(tagInfo.artist);
                        bool tagInfoPropertiesChanged = TagInfoPropertiesChanged(tagInfo, previousTagInfo);
                        if(tagInfoPropertiesChanged)
                        {
                            previousTagInfo = tagInfo;
                        }
                        return (title, artist, tagInfoPropertiesChanged);
                    }
                }
                else
                {
                    MessageBox.Show("BASS_TAG_GetFromURL method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bass assembly is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (string.Empty, string.Empty, true);
        }

        public bool BassInitialized()
        {
            return bassInitialized;
        }
    }
}