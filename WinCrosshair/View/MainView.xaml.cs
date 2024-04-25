using System.Windows;
using System.Windows.Controls;
using WinCrosshair.View.Windows;

namespace WinCrosshair.View
{



    public partial class MainView : UserControl
    {
        ToppingWindow toppingWindow = new ToppingWindow();


        public static readonly DependencyProperty TextProperty;
        public static readonly DependencyProperty MyTextsProperty;
        static MainView()
        {

            TextProperty = DependencyProperty.Register(
                        "Text",
                        typeof(string),
                        typeof(MainView),
                        new FrameworkPropertyMetadata(
                            string.Empty,
                            FrameworkPropertyMetadataOptions.AffectsMeasure |
                            FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnTextChanged)));

            MyTextsProperty = DependencyProperty.Register(
                       "MyTexts",
                       typeof(string[]),
                       typeof(MainView),
                       new FrameworkPropertyMetadata(
                           Array.Empty<string>(),
                           FrameworkPropertyMetadataOptions.AffectsMeasure |
                           FrameworkPropertyMetadataOptions.AffectsRender,
                           new PropertyChangedCallback(OnTextChanged)));
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public string[] MyTexts
        {
            get { return (string[])GetValue(MyTextsProperty); }
            set { SetValue(MyTextsProperty, value); }
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {


        }

        public MainView()
        {
            InitializeComponent();
            this.DataContext = this;

            this.Loaded += MainView_Loaded;


        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.MainWindow.IsActive)
                return;

            toppingWindow.Show();
        }
    }
}
