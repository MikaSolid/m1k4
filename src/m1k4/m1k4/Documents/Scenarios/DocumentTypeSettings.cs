using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class DocumentTypeSettings
    {
        public int Id { get { return DocumentType.Id; } }


        public DocumentType DocumentType { get; set; }

        public string Name { get { return DocumentType.Name; } }

        private List<PropertyDisplay> _propertyDisplays = new List<PropertyDisplay>();


        public DocumentTypeSettings(DocumentType docType)
        {
            DocumentType = docType;
            PropertyDisplays = DocumentType.Properties.Select(p => new PropertyDisplay(p)).ToList();
        }

        public List<PropertyDisplay> PropertyDisplays
        {
            get
            {
                return _propertyDisplays;
            }
            set
            {
                _propertyDisplays = value;
            }
        }
    }
}
