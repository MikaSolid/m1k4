using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class Slice
    {
        public static Slice Create(PropertyItem propertyItem)
        {
            switch (propertyItem.Property.PropertyType)
            {
                case PropertyType.Single:
                case PropertyType.Multi:
                case PropertyType.Hierarchical:
                    return new Slice(propertyItem);
                case PropertyType.Currency:
                case PropertyType.Decimal:
                case PropertyType.Integer:
                case PropertyType.Percentage:
                    return new NumberSlice(propertyItem);
                case PropertyType.Date:
                    return new DateSlice(propertyItem);
                default:
                    return new StringSlice(propertyItem);
            }
        }

        public static Slice NewViewPointSlice(PropertyItem propertyItem)
        {
            var slice = Create(propertyItem);
            slice.IsViewPointSlice = true;
            return slice;
        }

        protected Slice(PropertyItem propertyValue)
        {
            PropertyValue = propertyValue;
        }

        public PropertyItem PropertyValue { get; set; }

        public PropertyValue Val
        {
            get { return new PropertyValue(PropertyValue); }
        }

        public bool HasRange { get; set; }

        public bool IsViewPointSlice { get; set; }
    }

}
