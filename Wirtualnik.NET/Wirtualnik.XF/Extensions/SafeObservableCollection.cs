using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace Bimber.Extensions
{
    /// <summary>
    /// Based on https://github.com/tamirdresher/WinRTThreadSafeObservableCollection
    /// and https://stackoverflow.com/questions/51783872/xamarin-forms-listview-not-showing-content
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SafeObservableCollection<T> : ObservableCollection<T>
    {
        private readonly SemaphoreSlim locker = new SemaphoreSlim(1, 1);

        public SafeObservableCollection(IEnumerable<T> collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    base.Add(item);
                }
            }
        }

        public SafeObservableCollection()
        {
        }

        public new void Add(T item)
        {
            try
            {
                this.locker.Wait();
                base.Add(item);
            }
            finally
            {
                this.locker.Release();
            }
        }

        public new void Clear()
        {
            try
            {
                this.locker.Wait();
                base.Clear();
            }
            finally
            {
                this.locker.Release();
            }
        }

        public void Reset(IEnumerable<T> range)
        {
            this.Clear();

            if (range != null)
            {
                AddRange(range);
            }
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                Add(item);
            }

            //Raise the property change!
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);

            if (e.NewItems != null)
            {
                foreach (object item in e.NewItems)
                {
                    if (item is INotifyPropertyChanged notifyPropertyChangedItem)
                    {
                        notifyPropertyChangedItem.PropertyChanged += this.ItemPropertyChanged;
                    }
                }
            }

            if (e.OldItems != null)
            {
                foreach (object item in e.OldItems)
                {
                    if (item is INotifyPropertyChanged notifyPropertyChangedItem)
                    {
                        notifyPropertyChangedItem.PropertyChanged -= this.ItemPropertyChanged;
                    }
                }
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, this.IndexOf((T)sender));
            this.OnCollectionChanged(args);
        }
    }
}