using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels.User
{
    public record AppUserRegisterVM
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateOnly Birthdate { get; set; }
        public string University { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "You have to enter phone number.")]
        [RegularExpression(@"^(?:\+?994|0)?[\s\-]?(?:50|51|55|70|77|99|10|60)[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$",
        ErrorMessage = "Enter valid Azerbaijanian phone number (f.e: +994501234567 or 0501234567).")]
        public string PhoneNumber { get; set; } //055/050/051/070/077/099/010/060 regular expression
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
