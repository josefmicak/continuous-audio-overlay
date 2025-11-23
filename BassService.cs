using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Un4seen.Bass;

namespace ContinuousAudioOverlay
{
    public class BassService
    {
        private Assembly? _bassAssembly;
        private dynamic? _previousTagInfo;
        private static int _streamHandle;
        private Type? _bassType;
        private Type? _bassTagsType;
        private List<Radio> _radioList = new List<Radio>();
        private bool _bassInitialized = false;
        private SYNCPROC? _metaDataSync;
        public delegate void MetaDataChangedHandler(string title, string artist);
        public event MetaDataChangedHandler? OnMetaDataChanged;
        private CancellationTokenSource? _playRadioCts;
        private bool _radioPlaying = false;

        public BassService()
        {

        }

        private Task LoadBassAssembly(CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                ct.ThrowIfCancellationRequested();

                if (_bassAssembly != null)
                    return;

                string baseDir = AppContext.BaseDirectory;

                string bassNetPath = Path.Combine(baseDir, "Libraries", "Bass.Net.dll");

                if (!File.Exists(bassNetPath))
                    throw new FileNotFoundException("Bass.Net.dll not found.", bassNetPath);

                _bassAssembly = Assembly.LoadFrom(bassNetPath);

                _bassTagsType = _bassAssembly.GetType("Un4seen.Bass.AddOn.Tags.TAG_INFO")
                              ?? throw new TypeLoadException(
                                    "Could not find 'Un4seen.Bass.AddOn.Tags.TAG_INFO' in Bass.Net.dll.");

                _previousTagInfo = Activator.CreateInstance(_bassTagsType);
            }, ct);
        }

        public async Task<List<Radio>> GetRadioList()
        {
            string xmlFilePath = GetXmlFilePath();

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
                using (var writer = new StreamWriter(xmlFilePath, false))
                {
                    await doc.SaveAsync(writer, SaveOptions.None, CancellationToken.None);
                }
            }

            if (File.Exists(xmlFilePath))
            {
                string xmlContent = await File.ReadAllTextAsync(xmlFilePath);
                doc = XDocument.Parse(xmlContent);

                var radios = doc.Descendants("Radio")
                                .Select(radio => new Radio(
                                    radio.Element("RadioName")?.Value ?? string.Empty,
                                    radio.Element("RadioURL")?.Value ?? string.Empty
                                ))
                                .ToList();
                _radioList.Clear();
                _radioList.AddRange(radios);
            }

            return _radioList;
        }

        public void SaveRadioList(List<Radio> radioList)
        {
            string xmlFilePath = GetXmlFilePath();

            XElement root = new XElement("Radios");

            foreach (var radio in radioList)
            {
                XElement radioElement = new XElement("Radio",
                    new XElement("RadioName", radio.RadioName),
                    new XElement("RadioURL", radio.RadioURL)
                );
                root.Add(radioElement);
            }

            XDocument doc = new XDocument(root);

            doc.Save(xmlFilePath);
        }

        public async Task IndexChanged(int index)
        {
            string radioURL = _radioList[index].RadioURL;
            await PlayRadio(radioURL);
        }

        private void MetaDataSync(int handle, int channel, int data, IntPtr user)
        {
            string artist = string.Empty;
            string title = string.Empty;

            IntPtr metaPtr = Bass.BASS_ChannelGetTags(channel, BASSTag.BASS_TAG_META);
            if (metaPtr != IntPtr.Zero)
            {
                string? meta = Marshal.PtrToStringAnsi(metaPtr);
                if (!string.IsNullOrWhiteSpace(meta))
                {
                    int startIndex = meta.IndexOf('\'');
                    int endIndex = meta.LastIndexOf('\'');

                    if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
                    {
                        string streamTitle = meta.Substring(startIndex + 1, endIndex - startIndex - 1);
                        string[] parts = streamTitle.Split(new[] { " - " }, 2, StringSplitOptions.None);

                        artist = parts[0].Trim();
                        title = parts.Length > 1 ? parts[1].Trim() : string.Empty;
                    }
                }
            }

            OnMetaDataChanged?.Invoke(title, artist);
        }

        public void ReleaseBassResources()
        {
            _radioPlaying = false;

            if (!_bassInitialized)
            {
                return;
            }

            if (_bassAssembly != null && _bassType != null)
            {
                _playRadioCts?.Cancel();

                MethodInfo? bassChannelStopMethod = _bassType.GetMethod("BASS_ChannelStop");
                if (bassChannelStopMethod != null)
                {
                    bassChannelStopMethod.Invoke(null, new object[] { _streamHandle });
                }
                else
                {
                    MessageBox.Show("BASS_ChannelStop method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MethodInfo? bassStreamFreeMethod = _bassType.GetMethod("BASS_StreamFree");
                if (bassStreamFreeMethod != null)
                {
                    bassStreamFreeMethod.Invoke(null, new object[] { _streamHandle });
                }
                else
                {
                    MessageBox.Show("BASS_StreamFree method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MethodInfo? bassFreeMethod = _bassType.GetMethod("BASS_Free");
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
            //Function is likely to be removed in the future - for now it's kept for testing purposes
            if (_bassAssembly != null && _bassTagsType != null)
            {
                dynamic? tagInfo = Activator.CreateInstance(_bassTagsType);

                Type? bassTagsTypeLocal = _bassAssembly.GetType("Un4seen.Bass.AddOn.Tags.BassTags");
                MethodInfo? getFromUrlMethod = bassTagsTypeLocal?.GetMethod("BASS_TAG_GetFromURL", new[] { typeof(int), _bassTagsType });

                if (tagInfo != null && getFromUrlMethod != null)
                {
                    bool result = getFromUrlMethod?.Invoke(null, new object[] { _streamHandle, tagInfo! }) as bool? ?? false;

                    if (result && tagInfo?.title != null && tagInfo?.artist != null)
                    {
                        string title = WebUtility.HtmlDecode(tagInfo?.title);
                        string artist = WebUtility.HtmlDecode(tagInfo?.artist);
                        bool tagInfoPropertiesChanged = TagInfoPropertiesChanged(tagInfo, _previousTagInfo);
                        if (tagInfoPropertiesChanged)
                        {
                            _previousTagInfo = tagInfo;
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
            return _bassInitialized;
        }

        public async Task PlayRadio(string radioURL)
        {
            _playRadioCts?.Cancel();
            _playRadioCts = new CancellationTokenSource();
            var ct = _playRadioCts.Token;

            try
            {
                if (!_bassInitialized)
                {
                    _bassInitialized = true;
                    await LoadBassAssembly(ct);
                }

                if (_bassAssembly == null)
                {
                    MessageBox.Show("BASS library is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool started = await Task.Run(() =>
                {
                    ct.ThrowIfCancellationRequested();

                    _bassType = _bassAssembly.GetType("Un4seen.Bass.Bass");

                    MethodInfo? bassInitMethod = _bassType?.GetMethod("BASS_Init");
                    bool initSuccess = bassInitMethod?.Invoke(null, new object[] { -1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero }) as bool? ?? false;

                    if (!initSuccess)
                    {
                        return false;
                    }

                    MethodInfo? bassStreamCreateURLMethod = _bassType?.GetMethod("BASS_StreamCreateURL");
                    _streamHandle = (int?)bassStreamCreateURLMethod?.Invoke(null, new object[] { radioURL, 0, BASSFlag.BASS_DEFAULT, null!, IntPtr.Zero }) ?? 0;

                    ct.ThrowIfCancellationRequested();

                    if (_streamHandle != 0)
                    {
                        MethodInfo? bassChannelPlayMethod = _bassType?.GetMethod("BASS_ChannelPlay");
                        bassChannelPlayMethod?.Invoke(null, new object[] { _streamHandle, true });

                        Type[] parameterTypes = new Type[] { typeof(int), typeof(BASSAttribute), typeof(float) }; // Adjust the parameter types as necessary
                        MethodInfo? bassChannelSetAttributeMethod = _bassType?.GetMethod("BASS_ChannelSetAttribute", parameterTypes);
                        bassChannelSetAttributeMethod?.Invoke(null, new object[] { _streamHandle, BASSAttribute.BASS_ATTRIB_VOL, 0.1f });

                        _metaDataSync = new SYNCPROC(MetaDataSync);
                        int syncHandle = Bass.BASS_ChannelSetSync(
                            _streamHandle,
                            BASSSync.BASS_SYNC_META,
                            0,
                            _metaDataSync,
                            IntPtr.Zero
                        );

                        if (syncHandle == 0 && !ct.IsCancellationRequested)
                        {
                            throw new InvalidOperationException("Failed to set sync for metadata changes.");
                        }

                        MetaDataSync(0, _streamHandle, 0, IntPtr.Zero);
                    }
                    ct.ThrowIfCancellationRequested();
                    _radioPlaying = true;
                    return true;
                }, ct);

                if (!started)
                {
                    MessageBox.Show($"Radio could not be loaded.\r\nRadio URL: {radioURL}", "Error loading radio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (!ct.IsCancellationRequested)//No reason to show the error message in case the user canceled the operation
                {
                    MessageBox.Show($"Failed to start radio: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool GetRadioPlaying()
        {
            return _radioPlaying;
        }

        public void SetRadioPlaying(bool value)
        {
            _radioPlaying = value;
        }

        string GetXmlFilePath()
        {
            string appDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "ContinuousAudioOverlay");

            Directory.CreateDirectory(appDataFolder);

            return Path.Combine(appDataFolder, "RadioList.xml");
        }

    }
}
