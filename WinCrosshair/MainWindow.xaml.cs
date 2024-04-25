using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WinCrosshair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Tag as string)
            {
                case "close":
                    Process.GetCurrentProcess().Kill();
                    break;
                case "max":
                    Window window = (Window)((FrameworkElement)sender).TemplatedParent;
                    if (window.WindowState == System.Windows.WindowState.Normal)
                    {
                        window.WindowState = System.Windows.WindowState.Maximized;
                    }
                    else
                    {
                        window.WindowState = System.Windows.WindowState.Normal;
                    }
                    break;
                case "min":
                    ((Window)((FrameworkElement)sender).TemplatedParent).WindowState = WindowState.Minimized;

                    break;
            }
        }
    }
}