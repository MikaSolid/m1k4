using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class PropertyDisplay
    {
        private List<PropertyRule> _propertyRules = new List<PropertyRule>();

        private readonly Property _property;

        private bool _isVisible = true;
        private bool _isRequired;

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        public PropertyDisplay(Property property)
        {
            _property = property;
        }

        public List<PropertyRule> PropertyRules
        {
            get { return _propertyRules; }
            set { _propertyRules = value; }
        }

        public bool IsIdentifier { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsReadonly { get; set; }

        public bool IsRequired
        {
            get
            {
                return
                    _property.IsMandatory
                    || _isRequired
                    || PropertyRules.Any(r => r.GetType() == typeof(IsRequiredRule));
            }
            set { _isRequired = value; }
        }

        public bool IsMandatory { get { return _property.IsMandatory; } }

        public bool HasSuggestions { get; set; }

        public int Order { get; set; }

        public bool IsLastViewFavorite { get; set; }

        public List<PropertyItem> Favorites { get; set; }

        public Property Property { get { return _property; } }

        public bool IsLeftAligned
        {
            get
            {
                switch (_property.PropertyType)
                {
                    case PropertyType.Literal:
                    case PropertyType.Hierarchical:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public PropertyItem DefaultValue { get; set; }

        public string StringDefaultValue
        {
            get
            {
                if (DefaultValue != null)
                    return DefaultValue.StringValue;

                return Constants.NoDefault;
            }
        }
    }
}
