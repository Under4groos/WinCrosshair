using System.ComponentModel;

namespace WinCrosshair.ViewModel
{
    public class ViewModel_Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string path)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(path)));
        }

    }
}
