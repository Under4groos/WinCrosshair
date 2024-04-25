using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WinCrosshair.View.Controls
{
    /// <summary>
    /// Логика взаимодействия для ucMonitorControl.xaml
    /// </summary>
    public partial class ucMonitorControl : UserControl
    {

        #region NVVM
        public static readonly DependencyProperty ImageSourceProperty;
        public static readonly DependencyProperty ContentSourceProperty;
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public object Content
        {
            get { return (object)GetValue(ContentSourceProperty); }
            set { SetValue(ContentSourceProperty, value); }
        }
        static ucMonitorControl()
        {
            ImageSourceProperty = DependencyProperty.Register(
                       "Source",
                       typeof(ImageSource),
                       typeof(ucMonitorControl),
                       new FrameworkPropertyMetadata(
                           null,
                           FrameworkPropertyMetadataOptions.AffectsMeasure |
                           FrameworkPropertyMetadataOptions.AffectsRender,
                           new PropertyChangedCallback(Changed)));

            ContentSourceProperty = DependencyProperty.Register(
                       "Content",
                       typeof(object),
                       typeof(ucMonitorControl),
                       new FrameworkPropertyMetadata(
                           null,
                           FrameworkPropertyMetadataOptions.AffectsMeasure |
                           FrameworkPropertyMetadataOptions.AffectsRender,
                           new PropertyChangedCallback(Changed)));



        }

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ucMonitorControl uc)
            {
                switch (e.Property.Name)
                {
                    case "Source":
                        uc._image.ImageSource = e.NewValue as ImageSource;
                        break;
                    case "Content":
                        uc._label.Content = e.NewValue;
                        break;
                }


            }
        }
        #endregion
        public ucMonitorControl()
        {
            InitializeComponent();
        }
    }
}
