using System.ComponentModel;

namespace DevPace.WPF.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            CanExecuteChanged();
        }

        protected virtual void CanExecuteChanged()
        {

        }
    }
}
