using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OpenNetExtensions
{
    /// <summary>
    /// Helper base class for any object that would need to be Observable.
    /// Implements INotifyPropertyChanged and prevents firing extra events when the value
    /// has not actually changed.
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetValue<T>(string propertyName, ref T origValue, T newValue)
        {
            if (!Object.Equals(origValue, newValue))
            {
                origValue = newValue;
                NotifyPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
