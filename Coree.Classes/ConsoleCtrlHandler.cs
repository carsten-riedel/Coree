using System.Runtime.InteropServices;
//using System.Windows.Forms;


namespace Coree.Classes
{
    /* Sample implmentation 
        static ConsoleCtrlHandler ctrlHandler = new ConsoleCtrlHandler();

        static void Main(string[] args)
        {
            //do your event and threading magic here.
            ctrlHandler.CtrlTypeHandler += CtrlHandler_CtrlTypeHandler;
            ctrlHandler.WaitForConsoleCtrlSignal();
            Console.WriteLine($@"Hello, World! {ctrlHandler.CtrlType}");
        }

        private static void CtrlHandler_CtrlTypeHandler(object? sender, ConsoleCtrlHandler.CtrlTypeArgs e)
        {
            Console.WriteLine($@"Event will continue WaitForConsoleCtrlSignal ! {e.CtrlType}");
            //Kill thread dispose etc.
        }
     */

    public class ConsoleCtrlHandler
    {
        public class CtrlTypeArgs : EventArgs
        {
            public dwCtrlType CtrlType { get; set; }
        }

        public event EventHandler<CtrlTypeArgs> CtrlTypeHandler;

        public void OnCtrlTypeArgs(CtrlTypeArgs arg)
        {
            CtrlTypeHandler?.Invoke(this, arg);
            ConsoleCtrlSignal = true;
        }


        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler HandlerRoutine, bool Add);

        public bool ConsoleCtrlSignal = false;
        public dwCtrlType CtrlType;

        public enum dwCtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private delegate bool EventHandler(dwCtrlType sig);

        private readonly EventHandler handlerRoutine;

        public ConsoleCtrlHandler()
        {
            this.handlerRoutine += new EventHandler(HandlerRoutine);
            SetConsoleCtrlHandler(handlerRoutine, true);
        }

        private bool HandlerRoutine(dwCtrlType dwCtrlType)
        {
            if (CtrlTypeHandler != null)
            {
                CtrlType = dwCtrlType;
                OnCtrlTypeArgs(new CtrlTypeArgs() { CtrlType = dwCtrlType });
            }
            else
            {
                ConsoleCtrlSignal = true;
                CtrlType = dwCtrlType;
            }
            return true;
        }

        public void WaitForConsoleCtrlSignal()
        {
            while (!ConsoleCtrlSignal)
            {
                Thread.Sleep(100);
            }
        }
    }

}

// Alternative create a hidden window in the console that is able to get wndproc https://learn.microsoft.com/en-us/windows/console/setconsolectrlhandler 
// Rewrite code and definitions below to single manageable class. just stored here for interop definition (check of x64 x86 compatible)


/*
namespace Win32FromForms
{
    delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    class Win32Window
    {
        const UInt32 WS_OVERLAPPEDWINDOW = 0xcf0000;
        const UInt32 WS_VISIBLE = 0x10000000;
        const UInt32 CS_USEDEFAULT = 0x80000000;
        const UInt32 CS_DBLCLKS = 8;
        const UInt32 CS_VREDRAW = 1;
        const UInt32 CS_HREDRAW = 2;
        const UInt32 COLOR_WINDOW = 5;
        const UInt32 COLOR_BACKGROUND = 1;
        const UInt32 IDC_CROSS = 32515;
        const UInt32 WM_DESTROY = 2;
        const UInt32 WM_PAINT = 0x0f;
        const UInt32 WM_LBUTTONUP = 0x0202;
        const UInt32 WM_LBUTTONDBLCLK = 0x0203;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct WNDCLASSEX
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }


        private WndProc delegWndProc = myWndProc;

        [DllImport("user32.dll")]
        static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyWindow(IntPtr hWnd);


        [DllImport("user32.dll", SetLastError = true, EntryPoint = "CreateWindowEx")]
        public static extern IntPtr CreateWindowEx(
           int dwExStyle,
           UInt16 regResult,
           //string lpClassName,
           string lpWindowName,
           UInt32 dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "RegisterClassEx")]
        static extern System.UInt16 RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("user32.dll")]
        static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern void PostQuitMessage(int nExitCode);

        //[DllImport("user32.dll")]
        //static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
        //   uint wMsgFilterMax);

        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        static extern bool TranslateMessage([In] ref Message lpMsg);

        [DllImport("user32.dll")]
        static extern IntPtr DispatchMessage([In] ref Message lpmsg);

        

        internal bool create()
        {
            WNDCLASSEX wind_class = new WNDCLASSEX();
            wind_class.cbSize = Marshal.SizeOf(typeof(WNDCLASSEX));
            wind_class.style = (int)(CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS); //Doubleclicks are active
            wind_class.hbrBackground = (IntPtr)COLOR_BACKGROUND + 1; //Black background, +1 is necessary
            wind_class.cbClsExtra = 0;
            wind_class.cbWndExtra = 0;
            wind_class.hInstance = Marshal.GetHINSTANCE(this.GetType().Module); ;// alternative: Process.GetCurrentProcess().Handle;
            wind_class.hIcon = IntPtr.Zero;
            wind_class.hCursor = LoadCursor(IntPtr.Zero, (int)IDC_CROSS);// Crosshair cursor;
            wind_class.lpszMenuName = null;
            wind_class.lpszClassName = "myClass";
            wind_class.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(delegWndProc);
            wind_class.hIconSm = IntPtr.Zero;
            ushort regResult = RegisterClassEx(ref wind_class);

            if (regResult == 0)
            {
                uint error = GetLastError();
                return false;
            }
            string wndClass = wind_class.lpszClassName;

            //The next line did NOT work with me! When searching the web, the reason seems to be unclear! 
            //It resulted in a zero hWnd, but GetLastError resulted in zero (i.e. no error) as well !!??)
            //IntPtr hWnd = CreateWindowEx(0, wind_class.lpszClassName, "MyWnd", WS_OVERLAPPEDWINDOW | WS_VISIBLE, 0, 0, 30, 40, IntPtr.Zero, IntPtr.Zero, wind_class.hInstance, IntPtr.Zero);

            //This version worked and resulted in a non-zero hWnd
            IntPtr hWnd = CreateWindowEx(0, regResult, "Hello Win32", WS_OVERLAPPEDWINDOW | WS_VISIBLE, 0, 0, 300, 400, IntPtr.Zero, IntPtr.Zero, wind_class.hInstance, IntPtr.Zero);

            if (hWnd == ((IntPtr)0))
            {
                uint error = GetLastError();
                return false;
            }
            ShowWindow(hWnd, 1);
            UpdateWindow(hWnd);
            return true;

            //The explicit message pump is not necessary, messages are obviously dispatched by the framework.
            //However, if the while loop is implemented, the functions are called... Windows mysteries...
            //MSG msg;
            //while (GetMessage(out msg, IntPtr.Zero, 0, 0) != 0)
            //{
            //    TranslateMessage(ref msg);
            //    DispatchMessage(ref msg);
            //}
        }

        private static IntPtr myWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                // All GUI painting must be done here
                case WM_PAINT:
                    break;

                case WM_LBUTTONDBLCLK:
                    MessageBox.Show("Doubleclick");
                    break;

                case WM_DESTROY:
                    DestroyWindow(hWnd);

                    //If you want to shutdown the application, call the next function instead of DestroyWindow
                    //PostQuitMessage(0);
                    break;

                default:
                    break;
            }
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }
    }


}
*/