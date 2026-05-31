namespace Order.API.Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> Items { get; set; }
            = new List<OrderItem>();
    }
}
