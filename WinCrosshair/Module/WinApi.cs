using System.Runtime.InteropServices;
using System.Windows;
using WinCrosshair.Module.Monitir;

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

        [DllImport(Lib)]
        public static extern int _GetCursorPosX();






        #region user32 Methods
        [DllImport("user32.dll")]
        public extern static IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point p);
        #endregion

        #region gdi32 Methods
        [DllImport("gdi32.dll")]
        public static extern UInt64 BitBlt(IntPtr hDestDC, int x, int y,
           int nWidth, int nHeight, IntPtr hSrcDC,
           int xSrc, int ySrc, System.Int32 dwRop);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc,
        int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteObject(IntPtr hDc);
        #endregion

        #region dwmapi Methods
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, IntPtr dwAttribute, out RECT pvAttribute, int cbAttribute);
        #endregion









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
