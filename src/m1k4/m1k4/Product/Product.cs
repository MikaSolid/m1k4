using System;
using System.Collections.Generic;

namespace m1k4.Model
{
    public class Product
    {
        private List<ProductFeatureApplicability> _productFeatures = new List<ProductFeatureApplicability>();

        // private List<PriceComponent> _priceComponents = new List<PriceComponent>();

        private decimal _price;

        public int Id { get; set; }

        public string Code { get; set; }

        public string Barcode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime IntroductionDate { get; set; }

        public DateTime SalesDiscontinuationDate { get; set; }

        public DateTime SupportDiscontinuationDate { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public List<ProductFeatureApplicability> ProductFeatures
        {
            get { return _productFeatures; }
            set { _productFeatures = value; }
        }

        //public List<PriceComponent> PriceComponents
        //{
        //    get { return _priceComponents; }
        //    set { _priceComponents = value; }
        //}

        public decimal Price
        {
            get
            {
                return _price;
                // return _priceComponents.Sum(p => p.Price);
            }
            set
            {
                // _priceComponents.Add(new PriceComponent() { Price = value });
                _price = value;
            }
        }
    }
}