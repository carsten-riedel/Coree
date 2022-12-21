using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;


namespace Coree.Win32.SystemServices
{
    internal partial class Errhandling
    {
        internal class Managed
        {
            internal static uint GetLastError()
            {
                return DllImport.GetLastError();
            }

            internal static string GetLastErrorMessage()
            {
                return new Win32Exception((int)Managed.GetLastError()).Message;
            }
        }
    }
}

