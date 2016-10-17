using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Plasma.WpfFrameWork
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Set<T>(Expression<Func<T>> propertyExpression, ref T field, T newValue)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return;

            var oldValue = field;
            field = newValue;

            RaisePropertyChanged(propertyExpression, oldValue, field);
        }

        public virtual void RaisePropertyChanged<T>(string propertyName, T oldValue = default(T), T newValue = default(T))
        {
            if (String.IsNullOrEmpty(propertyName))
                throw new ArgumentException("This method cannot be called with an empty string", nameof(propertyName));

            RaisePropertyChanged(propertyName);
        }

        public virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, T oldValue, T newValue)
        {
            RaisePropertyChanged(propertyExpression);
        }

        public virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);

            if (!string.IsNullOrEmpty(propertyName))
                RaisePropertyChanged(propertyName);
        }
        protected static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            var body = propertyExpression.Body as MemberExpression;

            if (body == null)
                throw new ArgumentException("Invalid argument", nameof(propertyExpression));

            var property = body.Member as PropertyInfo;

            if (property == null)
                throw new ArgumentException("Argument is not a property", nameof(propertyExpression));

            return property.Name;
        }
    }
}
