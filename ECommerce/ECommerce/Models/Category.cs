using ECommerce.Models.BaseModels;

namespace ECommerce.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
//ORM - Object Relational Model Entity Framework Core 
//LINQ - Entity Framework Core - SQL