namespace NVShop.Service.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync();
    }
}