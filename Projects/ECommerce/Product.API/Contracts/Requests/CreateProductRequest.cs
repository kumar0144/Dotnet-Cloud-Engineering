namespace Product.API.Contracts.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

    }
}
