using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{

    public class HierarchicalPropertyItem : PropertyItem
    {
        private List<PropertyItem> _items = new List<PropertyItem>();

        public HierarchicalPropertyItem(Property property)
            : base(property)
        {
        }

        public HierarchicalPropertyItem Parent { get; set; }

        public string Path
        {
            get
            {
                if (Breadcrumb == null)
                    return String.Empty;

                return String.Join("/", Breadcrumb.Take(Breadcrumb.Count - 1).Select(b => b.StringValue));
            }
        }

        public bool IncludeSubFolders { get; set; }

        public Guid ParentId { get; set; }

        public List<PropertyItem> Breadcrumb { get; set; }

        public List<PropertyItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
}
