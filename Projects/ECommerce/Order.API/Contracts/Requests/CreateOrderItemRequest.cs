namespace Order.API.Contracts.Requests
{
    public class CreateOrderItemRequest
    {
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

    }
}
