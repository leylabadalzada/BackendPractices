namespace ECommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
//ORM - Object Relational Model Entity Framework Core 
//LINQ - Entity Framework Core - SQL