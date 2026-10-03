using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.ClasesEspeciales
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        public SortableBindingList(List<T> list) : base(list)
        {
        }

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => isSorted;

        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        protected override ListSortDirection SortDirectionCore => sortDirection;

        protected override void ApplySortCore(
            PropertyDescriptor prop,
            ListSortDirection direction)
        {
            var items = Items as List<T>;

            if (items == null)
                return;

            if (direction == ListSortDirection.Ascending)
            {
                items.Sort((x, y) =>
                    Comparer<object>.Default.Compare(
                        prop.GetValue(x),
                        prop.GetValue(y)));
            }
            else
            {
                items.Sort((x, y) =>
                    Comparer<object>.Default.Compare(
                        prop.GetValue(y),
                        prop.GetValue(x)));
            }

            sortProperty = prop;
            sortDirection = direction;
            isSorted = true;

            OnListChanged(new ListChangedEventArgs(
                ListChangedType.Reset,
                -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            sortProperty = null;
        }
    }
}
