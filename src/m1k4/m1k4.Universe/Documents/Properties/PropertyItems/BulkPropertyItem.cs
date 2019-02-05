using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class BulkPropertyItem : MultiPropertyItem
    {
        public BulkPropertyItem(Property property)
            : base(property)
        {
        }

        public override bool IsHeterogenous
        {
            get { return SelectedItems.Count > 1; }
        }

    }

}
