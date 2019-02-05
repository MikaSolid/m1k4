using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model
{
    public class ProductCategory
    {
        private List<ProductCategory> _subCategories = new List<ProductCategory>();

        public int Id { get; set; }

        public string Name { get; set; }

        public ProductCategory ParentCategory { get; set; }

        public List<ProductCategory> SubCategories
        {
            get { return _subCategories; }
            set { _subCategories = value; }
        }
    }
}