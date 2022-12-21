using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Coree.Win32.SystemServices
{
    internal partial class Services
    {
        internal class DllImport
        {
            //https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openscmanagerw

            [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);

            [DllImport("advapi32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CloseServiceHandle(IntPtr hSCObject);
        }
    }
}
