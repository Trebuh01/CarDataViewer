using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace lab10
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        public SortableBindingList() : base() { }

        public SortableBindingList(IEnumerable<T> enumerable) : base(new List<T>(enumerable)) { }

        public SortableBindingList(List<T> list) : base(list) { }

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => isSorted;

        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        protected override ListSortDirection SortDirectionCore => sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;

            if (items != null)
            {
                PropertyComparer<T> pc = new PropertyComparer<T>(prop, direction);
                items.Sort(pc);
                isSorted = true;
            }
            else
            {
                isSorted = false;
            }

            sortProperty = prop;
            sortDirection = direction;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            sortProperty = null;
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

                int result = Comparer.DefaultInvariant.Compare(xValue, yValue);

                if (direction == ListSortDirection.Descending)
                {
                    result = -result;
                }

                return result;
            }
        }
    }
}
