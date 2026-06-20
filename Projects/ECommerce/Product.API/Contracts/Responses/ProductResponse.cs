namespace Product.API.Contracts.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }

    }
}
