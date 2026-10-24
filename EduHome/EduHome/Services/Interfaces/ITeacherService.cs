using EduHome.ViewModels.Teacher;

namespace EduHome.Services.Interfaces
{
    public interface ITeacherService
    {
        Task RegisterAsync(TeacherRegisterVM vm);
        Task RemoveAccountAsync(string id);
        Task UpdateAsync(string id, TeacherUpdateVM vm);
        Task<List<TeacherGetAllVM>> GetAllAsync();
        Task<TeacherGetSingleVM> GetSingleAsync(string id);
        Task<bool> VerifyAccountAsync(string email, int otp);
        //ChangeEmail
        //ChangePassword
    }
}
