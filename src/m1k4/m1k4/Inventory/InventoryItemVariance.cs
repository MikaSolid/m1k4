using System;

namespace m1k4.Model
{
    public class InventoryItemVariance
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public DateTime InventoryDate { get; set; }

        public InventoryItem InventoryItem { get; set; }

        public int Quantity { get; set; }
    }
}