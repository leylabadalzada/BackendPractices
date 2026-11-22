namespace NVShop.Service.DTOs.Product
{
    public record ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
