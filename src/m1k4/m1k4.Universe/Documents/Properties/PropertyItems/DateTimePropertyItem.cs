using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class DateTimePropertyItem : MinMaxPropertyItem<Nullable<DateTime>>
    {
        private DateTime _value;

        public DateTimePropertyItem(Property property)
            : base(property)
        {
        }

        public override object Value
        {
            get
            {
                if (_value != DateTime.MinValue)
                    return _value;

                return null;
            }
            set
            {
                DateTime d;

                if (DateTime.TryParse(value.ToString(), out d))
                    _value = d;
                else if (DateTime.TryParseExact(value.ToString(),
                    Property.Format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out d))
                    _value = d;
            }
        }

        public override string ToString()
        {
            if (_value == DateTime.MinValue)
                return Constants.None;

            return _value.ToString(Property.Format ?? "M/d/yyyy hh:mm tt");
        }

        public override bool InRange
        {
            get
            {
                if (_value == DateTime.MinValue) return true;

                if (Property.MinValue != null && (DateTime)Property.MinValue > _value)
                    return false;

                if (Property.MaxValue != null && (DateTime)Property.MaxValue < _value)
                    return false;

                return true;
            }
        }
    }
}
