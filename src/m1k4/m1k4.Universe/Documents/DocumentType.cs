using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class DocumentType
    {
        private readonly List<Property> _properties = new List<Property>();

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Property> Properties { get { return _properties; } }

        public IEnumerable<Property> GlobalProperties { get { return _properties.Where(p => p.DocumentTypeId == 0); } }

        public IEnumerable<Property> TypeProperties { get { return _properties.Where(p => p.DocumentTypeId != 0); } }

        public PropertyItem CreateItem(int propertyId, int propertyValueId, string value)
        {
            return Properties.Single(p => p.Id == propertyId).CreateItem(propertyValueId, value);
        }
    }
}
