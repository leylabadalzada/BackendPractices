using NVShop.Core.Models.BaseModels;

namespace NVShop.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
