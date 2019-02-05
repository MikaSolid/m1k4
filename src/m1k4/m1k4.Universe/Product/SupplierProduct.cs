using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model
{
    public class SupplierProduct
    {
        public Product Product { get; set; }

        public Company Supplier { get; set; }

        public DateTime AvailableFromDate { get; set; }

        public DateTime AvailableThruDate { get; set; }
    }
}
