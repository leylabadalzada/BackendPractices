namespace ECommerce.ViewModels.Product
{
    public class ProductUpdateVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Client { get; set; }
        public DateOnly Date { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
    }
}
