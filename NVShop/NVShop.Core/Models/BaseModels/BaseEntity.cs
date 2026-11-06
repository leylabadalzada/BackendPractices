namespace NVShop.Core.Models.BaseModels
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly? DeletedAt { get; set; }
    }
}
