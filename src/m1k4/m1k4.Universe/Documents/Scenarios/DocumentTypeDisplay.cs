using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class DocumentTypeDisplay
    {
        private List<PropertyDisplay> _propertyDisplays = new List<PropertyDisplay>();

        private readonly DocumentType _documentType;

        public DocumentTypeDisplay(DocumentType documentType)
        {
            _documentType = documentType;
        }

        public DocumentType DocumentType { get { return _documentType; } }

        public List<PropertyDisplay> PropertyDisplays
        {
            get { return _propertyDisplays; }
            set { _propertyDisplays = value; }
        }
    }

}
