using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace WinCrosshair.ViewModel
{
    public class ViewModel_ucMonitors : ViewModel_Base
    {

        private ObservableCollection<(int, string, BitmapSource)> _Screens = new ObservableCollection<(int, string, BitmapSource)>();

        public ObservableCollection<(int, string, BitmapSource)> Screens
        {
            get { return _Screens; }
            set
            {
                _Screens = value;
                OnPropertyChanged(nameof(Screens));
            }
        }
        public void AddScreen((int, string, BitmapSource) v)
        {
            Screens.Add(v);
            OnPropertyChanged(nameof(Screens));

            Debug.WriteLine(_Screens.Count);
        }
        public ViewModel_ucMonitors()
        {

        }
    }
}
