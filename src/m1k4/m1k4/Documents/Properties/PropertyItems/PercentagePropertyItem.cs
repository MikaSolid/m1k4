using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class PercentagePropertyItem : DecimalPropertyItem
    {
        private Nullable<Decimal> _value;

        public PercentagePropertyItem(Property property)
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
                Decimal d;

                if (Decimal.TryParse(value.ToString().Replace("%", String.Empty).Replace(" ", String.Empty), out d))
                    _value = d;
                else
                    _value = null;
            }
        }

        public override string ToString()
        {
            if (!_value.HasValue)
                return Constants.None;

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSizes = new[] { 3 };
            nfi.NumberGroupSeparator = Property.Separator;
            nfi.NumberDecimalDigits = Property.DecimalPlaces;

            return String.Format("{0} %", _value.Value.ToString("N", nfi));
        }
    }

}
