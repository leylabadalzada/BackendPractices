namespace NVShop.Service.DTOs.Product
{
    public record ProductUpdateDto
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
    }
}
