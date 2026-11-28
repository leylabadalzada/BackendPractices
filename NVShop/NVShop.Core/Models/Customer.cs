using NVShop.Core.Models.BaseModels;

namespace NVShop.Core.Models
{
    public class Customer : BaseUser
    {
        public DateOnly Birthdate { get; set; }
    }
}
