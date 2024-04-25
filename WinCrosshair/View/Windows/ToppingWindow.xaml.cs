using System.Windows;
using System.Windows.Interop;
using WinCrosshair.Module;

namespace WinCrosshair.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ToppingWindow.xaml
    /// </summary>
    public partial class ToppingWindow : Window
    {
        public ToppingWindow()
        {
            InitializeComponent();

        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            WinApi._SetWindowPosG(hwnd);
        }
    }
}
