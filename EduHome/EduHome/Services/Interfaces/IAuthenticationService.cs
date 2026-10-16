using EduHome.ViewModels.Authentication;

namespace EduHome.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> ForgotPasswordAsync(string email);
        Task LoginAsync(LoginVM vm);
        Task LogoutAsync();
    }
}
