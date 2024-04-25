using System.Runtime.InteropServices;

namespace WinCrosshair.Module
{
    public static class WinApi
    {
#if DEBUG
        public const string Lib = @"C:\Users\UnderKo\source\repos\WinCrosshair\x64\Release\WinCrosshairLib.dll";
#else
        public const string Lib = "WinCrosshairLib.dll";
#endif

        [DllImport(Lib)]
        public static extern bool _SetWindowPosG(IntPtr hwnd);

        [DllImport(Lib)]
        public static extern bool _SetWinPosition(IntPtr hwnd, IntPtr hwhWndInsertAfternd, uint uFlags);







    }
}
