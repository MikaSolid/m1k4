using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class Scenario
    {
        public List<DocumentTypeSettings> _documentTypeSettings = new List<DocumentTypeSettings>();

        public List<PropertySettings> _propertySettings = new List<PropertySettings>();

        public Guid Id { get; set; }


        public List<DocumentTypeSettings> DocumentTypeSettings { get { return _documentTypeSettings; } }

        public List<PropertySettings> PropertySettings { get { return _propertySettings; } }

        public List<DocumentTypeDisplay> GetDisplays(IEnumerable<DocumentType> docTypes)
        {
            var dtds = new List<DocumentTypeDisplay>();

            foreach (var docType in docTypes)
            {
                var dtd = new DocumentTypeDisplay(docType);

                foreach (var prop in docType.Properties)
                {
                    var pd = new PropertyDisplay(prop);

                    var dts = DocumentTypeSettings.SingleOrDefault(dt => dt.Id == docType.Id);

                    if (dts != null)
                    {
                        var ps = dts.PropertyDisplays.SingleOrDefault(p => p.Property.Id == prop.Id);

                        if (ps != null)
                        {
                            pd.IsLastViewFavorite = ps.IsLastViewFavorite;
                            pd.IsRequired = ps.IsRequired;
                            pd.IsVisible = ps.IsVisible;
                            pd.IsIdentifier = ps.IsIdentifier;
                            pd.Order = ps.Order;
                        }
                    }

                    dtd.PropertyDisplays.Add(pd);
                }

                dtds.Add(dtd);
            }

            return dtds;
        }
    }
}