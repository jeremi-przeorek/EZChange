using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace EZChange.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
