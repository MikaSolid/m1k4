using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class IntegerPropertyItem : MinMaxPropertyItem<Int32>
    {
        private Nullable<Int32> _value;

        public IntegerPropertyItem(Property property)
            : base(property)
        {
        }

        public override object Value
        {
            get
            {
                return _value;
            }
            set
            {
                int d;

                if (Int32.TryParse(value.ToString().Replace(" ", String.Empty).Replace(",", String.Empty), out d))
                    _value = d;
                else
                    _value = null;
            }
        }

        public override string ToString()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSizes = new[] { 3 };
            nfi.NumberGroupSeparator = Property.Separator;
            nfi.NumberDecimalDigits = 0;

            return _value.HasValue ? _value.GetValueOrDefault().ToString("N", nfi) : Constants.None;
        }
    }
}