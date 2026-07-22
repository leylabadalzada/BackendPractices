using ECommerce.Models.BaseModels;

namespace ECommerce.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Client { get; set; }
        public DateOnly Date { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
