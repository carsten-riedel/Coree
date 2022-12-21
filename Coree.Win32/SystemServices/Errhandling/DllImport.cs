using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace Coree.Win32.SystemServices
{
    internal partial class Errhandling
    {
        internal class DllImport
        {
            [DllImport("kernel32.dll")]
            internal static extern uint GetLastError();
        }
    }
}
