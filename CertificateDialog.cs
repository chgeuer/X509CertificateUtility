namespace X509CertificateTool
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// P/Invoke wrapper for showing the Win32 Certificate dialog. 
    /// </summary>
    internal class CertificateDialog
    {
        private CertificateDialog() { }

        internal static void ShowFilePropertiesDialog(IntPtr hwnd, string directory, string file)
        {
            CertificateDialog.SHELLEXECUTEINFO shellexecuteinfo1 = new CertificateDialog.SHELLEXECUTEINFO
            {
                cbSize = Marshal.SizeOf(typeof(CertificateDialog.SHELLEXECUTEINFO)),
                fMask = 12,
                lpVerb = "Properties",
                hwnd = hwnd,
                lpParameters = null,
                lpDirectory = directory,
                lpFile = file,
                hInstApp = IntPtr.Zero,
                lpIDList = IntPtr.Zero,
                hkeyClass = IntPtr.Zero,
                hIcon = IntPtr.Zero,
                hProcess = IntPtr.Zero
            };

            IntPtr ptr1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CertificateDialog.SHELLEXECUTEINFO)));
            Marshal.StructureToPtr(shellexecuteinfo1, ptr1, false);
            SafeNativeMethods.ShellExecuteEx(ptr1);
            Marshal.FreeHGlobal(ptr1);
        }

        [StructLayout(LayoutKind.Sequential)]
        private class SHELLEXECUTEINFO
        {
            public int cbSize;
            public int fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            public string lpClass;
            public IntPtr hkeyClass;
            public int dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }
    }
}