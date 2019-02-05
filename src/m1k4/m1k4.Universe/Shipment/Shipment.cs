using System;
using System.Collections.Generic;

namespace m1k4.Model
{
    public class Shipment
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public Customer ShipFrom { get; set; }

        public Customer ShipTo { get; set; }

        public DateTime EstimatedReadyTime { get; set; }

        public DateTime PickupTime { get; set; }

        public DateTime EstimatedDeliveryTime { get; set; }

        public DateTime ActualDeliveryTime { get; set; }

        public string ShipmentInstructions { get; set; }

        public List<Good> Items { get; set; }
    }
}