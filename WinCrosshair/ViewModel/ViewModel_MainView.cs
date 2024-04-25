using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WinCrosshair.ViewModel
{
    public class ViewModel_MainView : ViewModel_Base
    {





        public ObservableCollection<string> MyTexts { get; set; } = new ObservableCollection<string>();



        public ViewModel_MainView()
        {
            this.PropertyChanged += ViewModel_MainView_PropertyChanged;
            for (int i = 0; i < 400; i++)
            {
                MyTexts.Add(i.ToString());
            }
            //OnPropertyChanged();
        }

        private void ViewModel_MainView_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
        }
    }
}
