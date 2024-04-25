using System.Runtime.InteropServices;

namespace WinCrosshair.Module
{
    public static class WinApi
    {

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

#if DEBUG
        public const string Lib = @"C:\Users\UnderKo\source\repos\WinCrosshair\x64\Release\WinCrosshairLib.dll";
#else
        public const string Lib = "WinCrosshairLib.dll";
#endif

        [DllImport(Lib)]
        public static extern bool _SetWindowPosG(IntPtr hwnd);

        [DllImport(Lib)]
        public static extern bool _SetWinPosition(IntPtr hwnd, IntPtr hwhWndInsertAfternd, uint uFlags);

        [DllImport(Lib)]
        public static extern bool _MakeTransparent(IntPtr hwnd);

        [DllImport(Lib)]
        public static extern bool _MakeNormal(IntPtr hwnd);

        [DllImport(Lib)]
        public static extern bool _HideWin_Tab(IntPtr hwnd);



        public static void MakeTransparent(IntPtr hwnd)
        {
            int windowLong = GetWindowLong(hwnd, -20);
            SetWindowLong(hwnd, -20, windowLong | 0x20);
        }
        public static void HideWin_Tab(IntPtr hwnd)
        {
            int WS_EX_TOOLWINDOW = 0x00000080;
            int GWL_EXSTYLE = (-20);
            int exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            exStyle |= WS_EX_TOOLWINDOW;
            SetWindowLong(hwnd, GWL_EXSTYLE, exStyle);
        }

        public static void MakeNormal(IntPtr hwnd)
        {
            int windowLong = GetWindowLong(hwnd, -20);
            SetWindowLong(hwnd, -20, windowLong & -33);
        }


    }
}
