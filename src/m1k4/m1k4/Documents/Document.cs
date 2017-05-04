using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class Document
    {
        public int Id { get; set; }

        private List<PropertyValue> _propertyValues = new List<PropertyValue>();

        public bool IsBroken
        {
            get
            {
                return PropertyValues.Any(pv => pv.Display.PropertyRules.Any(rule => !rule.Validate(pv.Item.StringValue)));
            }
        }
        public void SetValue(PropertyItem item)
        {
            PropertyValues.Single(pv => pv.Item.PropertyId == item.PropertyId).SetValue(item);

            // PropertyValues.Add(new PropertyValue(item));
        }

        public void SetValue(int propertyId, int propertyValueId, object value)
        {
            var val = PropertyValues.SingleOrDefault(pv => pv.Item.PropertyId == propertyId);

            if (val != null)
            {
                var vals = val.Item.Property.PropertyItems;

                PropertyItem item;

                if (value is Guid)
                    item = vals.FirstOrDefault(v => v.Id == (int)value);
                else
                    item = vals.FirstOrDefault(v => v.StringValue.ToLower() == value.ToString().ToLower());

                if (item != null)
                    SetValue(item);
                else
                {
                    if (val.Item.Property.PropertyType == PropertyType.Multi)
                    {
                        var multiItem = new MultiPropertyItem(val.Item.Property);
                        multiItem.SetValue(value.ToString());
                        val.SetValue(multiItem);
                    }
                    else if (val.Item.Property.PropertyType == PropertyType.Hierarchical)
                        val.Item.Value = val.Item.Property.CreateItem(propertyValueId, value);
                    else if (String.IsNullOrWhiteSpace(value.ToString()))
                        SetValue(val.Item.Property.None);
                    else
                        val.Item.Value = value;
                }
            }
        }

        public virtual List<PropertyValue> PropertyValues
        {
            get { return _propertyValues; }
            set { _propertyValues = value; }
        }

        public virtual PropertyItem FirstIdentifier
        {
            get
            {
                var primaryProperty = PropertyValues.OrderBy(i => i.Display.Order).FirstOrDefault(propertyValue => propertyValue.Display.IsIdentifier);

                if (primaryProperty != null && primaryProperty.Item.StringValue != Constants.None)
                    return primaryProperty.Item;

                if (SecondIdentifier == null)
                    return PropertyValues.Single(p => p.Item.Property.Name == "Name").Item;

                return null;
            }
        }

        public PropertyItem SecondIdentifier
        {
            get
            {
                var secondaryProperty = PropertyValues.OrderBy(i => i.Display.Order).Where(p => p.Display.IsIdentifier)
                    .Skip(1)
                    .FirstOrDefault();

                if (secondaryProperty != null && secondaryProperty.Item.StringValue != Constants.None)
                    return secondaryProperty.Item;

                return null;
            }
        }

        public string IdentifierString
        {
            get
            {
                string identifier = FirstIdentifier != null ? FirstIdentifier.StringValue : Constants.None;

                if (SecondIdentifier != null)
                    return String.Format("{0} | {1}", identifier, SecondIdentifier.StringValue);

                return identifier;
            }
        }

        public void ApplyDefaultValues(Scenario scenario)
        {
            var dtSettings = scenario.DocumentTypeSettings.SingleOrDefault(dt => dt.Id == _propertyValues.Single(p => p.Item.PropertyName == "Document Type").Item.Id);

            _propertyValues.ForEach(pv => pv.Display.IsReadonly = false);

            if (dtSettings != null)
            {
                foreach (var settings in dtSettings.PropertyDisplays)
                {
                    var propertyValue = PropertyValues.SingleOrDefault(pv => pv.Property.Id == settings.Property.Id);

                    if (//settings.Property.Id != Constants.DocumentTypePropertyId &&
                        settings.StringDefaultValue != Constants.NoDefault &&
                        settings.StringDefaultValue != Constants.None)
                    {
                        propertyValue.SetValue(settings.DefaultValue);
                    }
                }
            }
        }

        public void ApplyFilingScenario(Scenario scenario)
        {
            var dt = _propertyValues.SingleOrDefault(p => p.Item.PropertyName == "Document Type");

            if (dt != null)
            {
                var dtSettings = scenario.DocumentTypeSettings.SingleOrDefault(dts => dts.Id == dt.Item.Id);

                _propertyValues.ForEach(pv => pv.Display.IsReadonly = false);

                if (dtSettings != null)
                {
                    foreach (var settings in dtSettings.PropertyDisplays)
                    {
                        var propertyValue = PropertyValues.SingleOrDefault(pv => pv.Item.PropertyId == settings.Property.Id);

                        if (propertyValue != null)
                        {
                            propertyValue.Display.IsVisible = settings.IsVisible;
                            propertyValue.Display.IsReadonly = settings.IsReadonly;
                            propertyValue.Display.Order = settings.Order;
                            propertyValue.Display.IsIdentifier = settings.IsIdentifier;

                            propertyValue.Display.PropertyRules.Clear();

                            if (settings.IsRequired) // && settings.Property.Id != Constants.LocationPropertyId)
                                propertyValue.Display.PropertyRules.Add(new IsRequiredRule());
                        }
                    }
                }
            }
        }

        public bool IsFilteredOut(List<Slice> slices)
        {
            List<string> propertyNames = this.PropertyValues.Select(p => p.Item.PropertyName).ToList();

            if (!slices.Any())
                return false;

            foreach (var slice in slices)
            {
                if (String.IsNullOrEmpty(slice.PropertyValue.StringValue) || slice.PropertyValue.StringValue == Constants.None) continue;

                if (!propertyNames.Contains(slice.PropertyValue.PropertyName)) return true;

                if (PropertyValues.Any(p => p.Item.IsFilteredOut(slice))) return true;
            }

            return false;
        }
    }
}
