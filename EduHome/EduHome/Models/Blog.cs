using EduHome.Models.BaseModels;

namespace EduHome.Models
{
    public class Blog : BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        //teacher
        public int CategoryId { get; set; } //one terefdir
        public Category Category { get; set; } //navigation
    }
}
