using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WinCrosshair.Module.Monitir;

namespace WinCrosshair.View.Controls
{
    /// <summary>
    /// Логика взаимодействия для ucMonitors.xaml
    /// </summary>
    public partial class ucMonitors : UserControl
    {
        Monitors monitors = new Monitors();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public static readonly DependencyProperty ContentSourceProperty;

        public ObservableCollection<(int, string, BitmapSource)> Content
        {
            get { return (ObservableCollection<(int, string, BitmapSource)>)GetValue(ContentSourceProperty); }
            set { SetValue(ContentSourceProperty, value); }
        }
        static ucMonitors()
        {


            ContentSourceProperty = DependencyProperty.Register(
                       "Content",
                       typeof(ObservableCollection<(int, string, BitmapSource)>),
                       typeof(ucMonitors),
                       new FrameworkPropertyMetadata(
                           new ObservableCollection<(int, string, BitmapSource)>(),
                           FrameworkPropertyMetadataOptions.AffectsMeasure |
                           FrameworkPropertyMetadataOptions.AffectsRender,
                           new PropertyChangedCallback(Changed)));



        }

        private void Content_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _screens__.Children.Clear();
            foreach (var item in Content)
            {
                _screens__.Children.Add(new ucMonitorControl()
                {
                    Source = item.Item3 as BitmapSource,
                    Content = item.Item2,
                });
            }

        }

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }











        public ucMonitors()
        {
            InitializeComponent();
            Content.CollectionChanged += Content_CollectionChanged;
            this.Loaded += UcMonitors_Loaded;

        }

        private void UcMonitors_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            monitors.UpdateScreens();
            Content.Clear();
            for (int i = 0; i < monitors.Screens.Count; i++)
            {
                var m_ = monitors.Screens[i];
                var image__ = monitors.CaptureScreen(i);
                Content.Add((i, m_.DeviceName, image__));
            }

        }

    }
}
