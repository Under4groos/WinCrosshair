using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace WinCrosshair.Module.Monitir
{
    public class Monitors
    {
        public Action UpdateMonitors;

        public List<MONITORINFOEX> Screens = new List<MONITORINFOEX>();
        public MONITORINFOEX CurMonitor = default;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFOEX lpmi);

        private delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        [DllImport("user32.dll")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

        private bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
        {
            MONITORINFOEX mi = new MONITORINFOEX();
            mi.Size = Marshal.SizeOf(typeof(MONITORINFOEX));
            if (GetMonitorInfo(hMonitor, ref mi))
            {
                Screens.Add(mi);

                if (WinApi._GetCursorPosX() > mi.Monitor.Left)
                {
                    CurMonitor = mi;

                }


            }

            return true;
        }

        public BitmapSource CaptureScreen(int id)
        {
            try
            {
                MONITORINFOEX m__ = Screens[id];

                return CaptureRegion(
                    m__.Monitor.Left, m__.Monitor.Top,
                   (int)m__.Monitor.GetSize().Width, (int)m__.Monitor.GetSize().Height

                    );
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }

        private static BitmapSource CaptureRegion(int Left, int Top, int Width, int Height)
        {
            IntPtr dc1 = WinApi.GetDC(WinApi.GetDesktopWindow());
            IntPtr dc2 = WinApi.CreateCompatibleDC(dc1);


            IntPtr hBitmap = WinApi.CreateCompatibleBitmap(dc1, Width, Height);

            WinApi.SelectObject(dc2, hBitmap);
            WinApi.BitBlt(dc2, 0, 0, Width, Height, dc1, Left, Top, 0x00CC0020);


            BitmapSource bSource = Imaging.CreateBitmapSourceFromHBitmap(hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());


            WinApi.DeleteObject(hBitmap);
            WinApi.ReleaseDC(IntPtr.Zero, dc1);
            WinApi.ReleaseDC(IntPtr.Zero, dc2);

            return bSource;
        }

        public void UpdateScreens()
        {
            Screens.Clear();
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnumProc, IntPtr.Zero);
            if (UpdateMonitors != null)
                UpdateMonitors();
        }
        public void UpdateActialMonitor()
        {
            foreach (MONITORINFOEX monitor in Screens)
            {
                if (WinApi._GetCursorPosX() > monitor.Monitor.Left)
                {
                    CurMonitor = monitor;

                }
            }

        }
    }
}
