using System.Runtime.InteropServices;
using System;

namespace Coree.Win32.SystemServices
{
    //https://learn.microsoft.com/de-de/windows/win32/ 
    //https://learn.microsoft.com/de-de/windows/win32/apiindex/windows-api-list 
    //https://learn.microsoft.com/de-de/windows/win32/api/_base/

    internal partial class Services
    {

        //https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openservicew
        


        public static void test()
        {
            
            IntPtr handle = Managed.OpenSCManager();

                Managed.CloseServiceHandle(handle);
  
        }
    }
}