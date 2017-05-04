using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class PropertyValue
    {
        private PropertyItem _item;
        private PropertyDisplay _display;

        public PropertyValue(PropertyItem item)
        {
            if (item.Property == null)
                throw new NotSupportedException("You cannot create a property value from item without property.");

            _item = item;

            _display = new PropertyDisplay(_item.Property);
        }

        public PropertyItem Item
        {
            get { return _item; }
        }

        public void SetValue(PropertyItem item)
        {
            _item = item;
        }

        public Property Property
        {
            get
            {
                return _item.Property;
            }
        }


        public PropertyDisplay Display
        {
            get { return _display; }
        }

        public bool IsBroken
        {
            get { return Display.PropertyRules.Any(rule => !rule.Validate(_item.StringValue)) || !_item.InRange; }
        }

    }
}
