using EduHome.ViewModels.User;

namespace EduHome.Services.Interfaces
{
    public interface ITeacherService
    {
        Task Register(TeacherRegisterVM vm);
        Task RegisterUser(AppUserRegisterVM vm);
        Task RemoveAccount(string id);
        Task UpdateAsync(string id, TeacherUpdateVM vm);
        //ChangeEmail
        //ChangePassword

    }
}
