using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class PropertyItem
    {
        private readonly Property _property;
        private object _value;


        #region Constructors and factories

        protected PropertyItem(Property property)
        {
            _property = property;
        }

        public static PropertyItem Create(Property property)
        {
            return Create(0, property);
        }

        public static PropertyItem Create(int id, Property property, object value = null)
        {
            PropertyItem pv;

            switch (property.PropertyType)
            {
                case PropertyType.Hierarchical:
                    pv = new HierarchicalPropertyItem(property);
                    break;
                case PropertyType.Date:
                    pv = new DateTimePropertyItem(property);
                    break;
                case PropertyType.Integer:
                    pv = new IntegerPropertyItem(property);
                    break;
                case PropertyType.Percentage:
                    pv = new PercentagePropertyItem(property);
                    break;
                case PropertyType.Currency:
                    pv = new CurrencyPropertyItem(property);
                    break;
                case PropertyType.Decimal:
                    pv = new DecimalPropertyItem(property);
                    break;
                default:
                    pv = new StringPropertyItem(property);
                    break;
            }

            pv.Id = id;

            if (value != null)
            {
                pv.Value = value;
            }

            return pv;
        }

        #endregion

        public int Id { get; protected set; }


        public Property Property { get { return _property; } }

        public bool IsFavorite { get; set; }


        public virtual object Value
        {
            get { return _value; }
            set
            {
                if (value is PropertyItem)
                    Id = ((PropertyItem)value).Id;

                _value = value;
            }
        }

        public string StringValue
        {
            get
            {
                return Value == null || (Value is Guid && (Guid)Value == Guid.Empty) || String.IsNullOrWhiteSpace(ToString()) ? Constants.None : ToString();
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public string PropertyName { get { return _property.Name; } }

        public int DocumentTypeId { get { return _property.DocumentTypeId; } }

        public int PropertyId { get { return _property.Id; } }


        public virtual bool InRange
        {
            get { return true; }
        }

        public virtual bool IsHeterogenous
        {
            get { return false; }
        }

        public bool IsFilteredOut(Slice slice)
        {
            var slicePropertyValue = slice.PropertyValue;

            if (_property.Name == slicePropertyValue.PropertyName &&
                (StringValue != slicePropertyValue.StringValue))
                return true;

            return false;

        }


    }
}
