using System;
using static Coree.Win32.SystemServices.Services.Enumerations;

namespace Coree.Win32.SystemServices
{
    internal partial class Services
    {
        internal class Managed
        {
            public static IntPtr OpenSCManager(string machineName = null, string databaseName = null, SCM_ACCESS scm_access = SCM_ACCESS.SC_MANAGER_ALL_ACCESS)
            {
                return DllImport.OpenSCManager(machineName, databaseName, (uint)scm_access);
            }

            public static bool CloseServiceHandle(IntPtr hSCObject)
            {
                return DllImport.CloseServiceHandle(hSCObject);
            }
        }
    }
}