using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model
{
    public class ProductFeatureApplicability
    {
        public ProductFeature ProductFeatures { get; set; }

        
        public DateTime FromDate { get; set; }

        
        public DateTime ToDate { get; set; }
    }
}