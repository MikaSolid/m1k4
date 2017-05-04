using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class Property
    {
        private List<PropertyItem> _propertyItems = new List<PropertyItem>();

        private PropertyType _propertyType = PropertyType.Literal;

        public Property(int propertyId, string propertyName)
        {
            Id = propertyId;
            Name = propertyName;
        }

        #region Factory methods

        public PropertyItem CreateItem(int id, object value)
        {
            return PropertyItem.Create(id, this, value);
        }

        #endregion

        public PropertyItem None
        {
            get
            {
                return PropertyItem.Create(0, this);
            }
        }

        public PropertyItem NoDefault
        {
            get
            {
                return PropertyItem.Create(0, this, Constants.NoDefault);
            }
        }

        public int Id { get; private set; }

        public string Name { get; set; }

        public PropertyType PropertyType
        {
            get { return _propertyType; }
            set { _propertyType = value; }
        }

        public int DocumentTypeId { get; set; }

        public List<PropertyItem> PropertyItems
        {
            get { return _propertyItems; }
            set { _propertyItems = value; }
        }

        public bool IsNew { get; set; }

        public object MinValue { get; set; }

        public object MaxValue { get; set; }

        public string Format { get; set; }

        public bool IsMandatory { get; set; }

        public string Symbol { get; set; }

        public int DecimalPlaces { get; set; }

        public string Separator { get; set; }

    }
}