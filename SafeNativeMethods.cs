namespace X509CertificateTool;

using System;
using System.Runtime.InteropServices;

internal static class SafeNativeMethods
{
    [DllImport("Shell32.dll", CharSet = CharSet.Auto)]
    internal static extern int ShellExecuteEx(IntPtr shinfo);
}
