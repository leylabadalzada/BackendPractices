using EduHome.ViewModels.User;

namespace EduHome.Services.Interfaces
{
    public interface ITeacherService
    {
        Task Register(TeacherRegisterVM vm);
        Task RegisterUser(AppUserRegisterVM vm);
        //RemoveAccount
        //ChangeEmail
        //ChangePassword
        //Update
    }
}
