using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class CurrencyPropertyItem : DecimalPropertyItem
    {
        private Nullable<Decimal> _value;

        internal CurrencyPropertyItem(Property property)
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

                var val = value.ToString().Replace(" ", String.Empty);

                if (!String.IsNullOrEmpty(Property.Symbol))
                    val = val.Replace(Property.Symbol, String.Empty);

                if (Decimal.TryParse(val, out d))
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
            nfi.NumberDecimalDigits = Property.DecimalPlaces;

            return _value.HasValue ? String.Format("{0} {1}", _value.GetValueOrDefault().ToString("N", nfi), Property.Symbol) : Constants.None;
        }
    }
}