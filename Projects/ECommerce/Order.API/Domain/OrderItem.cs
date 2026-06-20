namespace Order.API.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Guid OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Order Order { get; set; } = null!;

    }
}
