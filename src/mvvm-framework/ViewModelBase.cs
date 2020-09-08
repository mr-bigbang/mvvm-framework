using NLog;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Baumann
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected Logger Log { get; private set; }

        public ViewModelBase()
        {
            // See https://github.com/NLog/NLog/wiki/How-to-create-Logger-for-sub-classes
            Log = LogManager.GetLogger(GetType().ToString());
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region SetValue
        //https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/built-in-types
        /*
         * Value types
         */
        protected virtual void SetValue(ref bool property, bool value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref sbyte property, sbyte value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref byte property, byte value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref char property, char value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref short property, short value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref ushort property, ushort value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref int property, int value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref uint property, uint value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref long property, long value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref ulong property, ulong value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref float property, float value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref double property, double value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void SetValue(ref decimal property, decimal value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        /*
         * Reference types
         */
        protected virtual void SetValue(ref string property, string value, [CallerMemberName] string propertyName = null)
        {
            if (property == value) return;
            property = value;
            OnPropertyChanged(propertyName);
        }
        #endregion
    }
}
