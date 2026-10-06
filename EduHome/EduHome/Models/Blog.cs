using EduHome.Models.BaseModels;

namespace EduHome.Models
{
    public class Blog : BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CategoryId { get; set; } //one terefdir
        public Category Category { get; set; } //navigation

    }
}
