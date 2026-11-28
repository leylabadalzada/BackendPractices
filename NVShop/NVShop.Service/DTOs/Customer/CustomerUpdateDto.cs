namespace NVShop.Service.DTOs.Customer
{
    public record CustomerUpdateDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateOnly? Birthdate { get; set; }
    }
}
