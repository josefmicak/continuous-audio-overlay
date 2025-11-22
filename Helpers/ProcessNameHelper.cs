using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ContinuousAudioOverlay.Helpers
{
    public static class ProcessNameHelper
    {
        [DllImport("shell32.dll", SetLastError = true)]
        static extern int SHGetPropertyStoreForWindow(IntPtr hwnd, ref Guid iid, out IPropertyStore propertyStore);

        [ComImport]
        [Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IPropertyStore
        {
            int GetCount([Out] out uint cProps);
            int GetAt([In] uint iProp, out PropertyKey pkey);
            int GetValue([In] ref PropertyKey key, [Out] PropVariant pv);
            int SetValue([In] ref PropertyKey key, [In] PropVariant pv);
            int Commit();
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        struct PropertyKey
        {
            public Guid fmtid;
            public uint pid;
            public PropertyKey(Guid formatId, uint propertyId)
            {
                fmtid = formatId;
                pid = propertyId;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public class PropVariant : IDisposable
        {
            [FieldOffset(0)] public ushort vt;
            [FieldOffset(8)] public IntPtr pointerValue;

            public void Dispose()
            {
                if (vt == 31 && pointerValue != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pointerValue);
                }
            }
            public string? GetValue()
            {
                if (vt == 31 && pointerValue != IntPtr.Zero)
                    return Marshal.PtrToStringUni(pointerValue);
                return null;
            }
        }

        static readonly PropertyKey PKEY_AppUserModel_ID = new PropertyKey(
            new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3"), 5);

        public static string GetReadableProcessName(string sourceAppUserModelId)
        {
            foreach (Process proc in Process.GetProcesses())
            {
                try
                {
                    IntPtr hwnd = proc.MainWindowHandle;
                    if (hwnd == IntPtr.Zero) continue;

                    Guid iid = typeof(IPropertyStore).GUID;
                    int hr = SHGetPropertyStoreForWindow(hwnd, ref iid, out var propStore);
                    if (hr == 0 && propStore != null)
                    {
                        using (var pv = new PropVariant())
                        {
                            PropertyKey key = PKEY_AppUserModel_ID;
                            int hr2 = propStore.GetValue(ref key, pv);
                            if (hr2 == 0)
                            {
                                string? appUserModelId = pv.GetValue();
                                if (string.Equals(appUserModelId, sourceAppUserModelId, StringComparison.OrdinalIgnoreCase))
                                {
                                    string fileDesc = string.Empty;
                                    try
                                    {
                                        fileDesc = proc.MainModule?.FileVersionInfo.FileDescription ?? string.Empty;
                                        if (!string.IsNullOrEmpty(fileDesc))
                                            return fileDesc;
                                        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(proc.ProcessName);
                                    }
                                    catch
                                    {
                                        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(proc.ProcessName);
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            //Fallback
            if (sourceAppUserModelId.Contains("_"))
            {
                string[] parts = sourceAppUserModelId.Split('_', '!');
                if (parts.Length > 1)
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parts[0]);
            }

            return sourceAppUserModelId ?? "<no source>";
        }

        public static string FormatProcessName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string name = input.EndsWith(".exe", StringComparison.OrdinalIgnoreCase)
                ? input.Substring(0, input.Length - 4)
                : input;

            if (name.Length > 1)
                name = char.ToUpper(name[0]) + name.Substring(1);
            else
                name = name.ToUpper();

            return name;
        }
    }
}
