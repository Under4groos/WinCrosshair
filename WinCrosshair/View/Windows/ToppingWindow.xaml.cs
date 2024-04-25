using System.ComponentModel;
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
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        #region NVVM
        public static readonly DependencyProperty closingProperty;
        public static readonly DependencyProperty positionProperty;
        public bool IsClosing
        {
            get { return (bool)GetValue(closingProperty); }
            set { SetValue(closingProperty, value); }
        }
        public Point Position
        {
            get { return (Point)GetValue(positionProperty); }
            set { SetValue(positionProperty, value); }
        }
        static ToppingWindow()
        {
            positionProperty = DependencyProperty.Register(
                       "Position",
                       typeof(Point),
                       typeof(ToppingWindow),
                       new FrameworkPropertyMetadata(
                           new Point(),
                           FrameworkPropertyMetadataOptions.AffectsMeasure |
                           FrameworkPropertyMetadataOptions.AffectsRender,
                           new PropertyChangedCallback(OnTextChanged)));
            closingProperty = DependencyProperty.Register(
                        "IsClosing",
                        typeof(bool),
                        typeof(ToppingWindow),
                        new FrameworkPropertyMetadata(
                            false,
                            FrameworkPropertyMetadataOptions.AffectsMeasure |
                            FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnTextChanged)));


        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ToppingWindow window)
            {
                window.Left = window.Position.X;
                window.Top = window.Position.Y;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            IsClosing = true;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            IsClosing = true;
        }

        #endregion
        public ToppingWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        Random R = new Random();
        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            SetTop();

            this.Position = new Point(100 + R.Next(200), 100 + R.Next(200));
        }
        public void SetTop()
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            WinApi._SetWindowPosG(hwnd);
            WinApi._MakeTransparent(hwnd);
            WinApi._HideWin_Tab(hwnd);
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            SetTop();
        }
    }
}
