using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace lab10
{
    public class SortableSearchableBindingList<T> : BindingList<T>
    {
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;
        private bool isSorted; 
        private readonly bool supportsSorting;
        private readonly bool supportsSearching;

        public SortableSearchableBindingList() : base()
        {
            supportsSorting = true;
            supportsSearching = true;
        }

        public SortableSearchableBindingList(IEnumerable<T> enumerable) : base(new List<T>(enumerable))
        {
            supportsSorting = true;
            supportsSearching = true;
        }

        public SortableSearchableBindingList(List<T> list) : base(list)
        {
            supportsSorting = true;
            supportsSearching = true;
        }

        protected override bool SupportsSortingCore => supportsSorting;

        protected override bool IsSortedCore => isSorted;

        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        protected override ListSortDirection SortDirectionCore => sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;

            if (items != null)
            {
                if (prop.PropertyType.GetInterface("IComparable") != null)
                {
                    items.Sort(new PropertyComparer<T>(prop, direction));
                    sortProperty = prop;
                    sortDirection = direction;
                    isSorted = true;
                }
                else
                {
                    throw new InvalidOperationException("Cannot sort by " + prop.Name + ". This" +
                        " property does not implement IComparable");
                }
            }
            else
            {
                throw new InvalidOperationException("Items collection is null");
            }
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            sortProperty = null;
            sortDirection = ListSortDirection.Ascending;
        }

        protected override bool SupportsSearchingCore => supportsSearching;

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            List<T> items = this.Items as List<T>;

            if (key == null)
                throw new ArgumentNullException("key");

            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    T item = items[i];
                    object value = prop.GetValue(item);

                    if (value != null && value.Equals(key))
                        return i;
                }
            }
            return -1;
        }

        public int Find(string property, object key)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor prop = properties.Find(property, true);

            if (prop == null)
                throw new ArgumentException("Property not found", nameof(property));

            return FindCore(prop, key);
        }

        public void Sort(string propertyName, ListSortDirection direction)
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(T)).Find(propertyName, true);
            if (prop != null)
            {
                ApplySortCore(prop, direction);
            }
            else
            {
                throw new ArgumentException("Invalid property name", nameof(propertyName));
            }
        }

        private class PropertyComparer<U> : IComparer<U>
        {
            private PropertyDescriptor prop;
            private ListSortDirection direction;

            public PropertyComparer(PropertyDescriptor prop, ListSortDirection direction)
            {
                this.prop = prop;
                this.direction = direction;
            }

            public int Compare(U x, U y)
            {
                object xValue = prop.GetValue(x);
                object yValue = prop.GetValue(y);

                int result;

                if (xValue is IComparable xComparable && yValue is IComparable yComparable)
                {
                    result = xComparable.CompareTo(yValue);
                }
                else
                {
                    throw new ArgumentException("Cannot compare values");
                }

                if (direction == ListSortDirection.Descending)
                {
                    result = -result;
                }

                return result;
            }
        }
    }
}
