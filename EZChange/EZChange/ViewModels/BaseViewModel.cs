using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EZChange.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel()
        {
        }

        protected BaseViewModel(IPageService pageService)
        {
            _pageService = pageService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected IPageService _pageService;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string callerName = null)
        {
            var equalityComparer = EqualityComparer<T>.Default;
            if(equalityComparer.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            OnPropertyChanged(callerName);
        }
    }
}
