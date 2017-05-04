using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class MultiPropertyItem : PropertyItem
    {
        private List<PropertyItem> _selectedItems = new List<PropertyItem>();

        public MultiPropertyItem(Property property)
            : base(property)
        {
        }

        public List<PropertyItem> SelectedItems
        {
            get { return _selectedItems; }
            set { _selectedItems = value; }
        }

        public override object Value
        {
            get { return SelectedItems; }
            set { SelectedItems = (List<PropertyItem>)value; }
        }

        public override string ToString()
        {
            return String.Join(", ", SelectedItems.Select(i => i.StringValue).ToArray());
        }

        public void SetValue(string newValue)
        {
            SelectedItems.Clear();

            foreach (var item in newValue.Split(','))
            {
                var existingPropertyValue =
                    Property.PropertyItems.FirstOrDefault(pv => pv.StringValue == item.Trim()) ??
                    Property.CreateItem(0, item.Trim());

                SelectedItems.Add(existingPropertyValue);
            }
        }
    }
}
