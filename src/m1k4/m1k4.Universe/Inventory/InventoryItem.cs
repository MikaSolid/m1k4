using System.Collections.Generic;

namespace m1k4.Model
{
    public class InventoryItem
    {
        public InventoryItem()
        {
            Product = new Product();
        }

        private List<InventoryItemVariance> _variances = new List<InventoryItemVariance>();

        public int Id { get; set; }

        public Product Product { get; set; }

        public InventoryItemStatusType Status { get; set; }

        public Facility Location { get; set; }

        public Container Container { get; set; }

        public List<InventoryItemVariance> Variances
        {
            get { return _variances; }
            set { _variances = value; }
        }
    }
}