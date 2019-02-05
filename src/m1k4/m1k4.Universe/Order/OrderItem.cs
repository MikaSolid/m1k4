namespace m1k4.Model
{
    public class OrderItem
    {
        public int Id { get; set; }

        public decimal Quantity { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice { get { return Product != null ? Product.Price : 0; } }

        public string Comment { get; set; }

        public decimal TotalPrice { get { return UnitPrice * Quantity; } }
    }
}