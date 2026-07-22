namespace ECommerce.Models.BaseModels
{
    public abstract class BaseEntity //kod tekrarinin qarsisini almaq ucundur. Demek ki, birbasa BaseEntity-den obyekt yaradilmir. Bize sadece mirasliqla xidmet edir.
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
