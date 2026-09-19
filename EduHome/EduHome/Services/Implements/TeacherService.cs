using EduHome.Extensions;
using EduHome.Models;
using EduHome.Models.BaseModels;
using EduHome.Services.Interfaces;
using EduHome.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Services.Implements
{
    public class TeacherService : ITeacherService
    {
        readonly UserManager<BaseUser> _userManager;
        readonly IWebHostEnvironment _env;

        public TeacherService(UserManager<BaseUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task Register(TeacherRegisterVM vm)
        {
            var teacher = new Teacher
            {
                Degree = vm.Degree,
                Description = vm.Description,
                Email = vm.Email,
                ExperienceInYear = vm.ExperienceInYear,
                Faculty = vm.Faculty,
                Firstname = vm.Firstname,
                Lastname = vm.Lastname,
                PhoneNumber = vm.PhoneNumber,
                Speciality = vm.Speciality,
                UserName = vm.Username,
                Image = vm.Image.UploadFile(_env.WebRootPath, "images/user")
            };

            var result = await _userManager.CreateAsync(teacher, vm.Password);
            if (!result.Succeeded) throw new Exception("Register user failed!");

            result = await _userManager.AddToRoleAsync(teacher, "Teacher");
            if (!result.Succeeded) throw new Exception("Add role failed!");
        }

        public async Task RegisterUser(AppUserRegisterVM vm)
        {
            var user = new AppUser
            {
                Email = vm.Email,
                Firstname = vm.Firstname,
                Lastname = vm.Lastname,
                PhoneNumber = vm.PhoneNumber,
                BirthDate = vm.Birthdate,
                University = vm.University,
                UserName = vm.Username
            };

            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded) throw new Exception(result.Errors.FirstOrDefault().Description);

            result = await _userManager.AddToRoleAsync(user, "Student");
            if (!result.Succeeded) throw new Exception(result.Errors.FirstOrDefault().Description);
        }

        public async Task RemoveAccount(string id)
        {
            var teacher = await _userManager.Users.OfType<Teacher>().FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null) throw new Exception("Teacher not found!");

            var path = $"{_env.WebRootPath}/images/user/{teacher.Image}";
            if (File.Exists(path)) File.Delete(path);

            var result = await _userManager.DeleteAsync(teacher);
            if (!result.Succeeded) throw new Exception(result.Errors.FirstOrDefault().Description);
        }

        public async Task UpdateAsync(string id, TeacherUpdateVM vm)
        {
            var teacher = await _userManager.Users.OfType<Teacher>().FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null) throw new Exception("Teacher not found!");

            if (vm.Image != null)
            {
                var path = $"{_env.WebRootPath}/images/user/{teacher.Image}";
                if (File.Exists(path)) File.Delete(path);

                teacher.Image = vm.Image.UploadFile(_env.WebRootPath, "images/user");
            }

            teacher.Faculty = vm.Faculty;
            teacher.Firstname = vm.Firstname;
            teacher.Lastname = vm.Lastname;
            teacher.Degree = vm.Degree;
            teacher.Description = vm.Description;
            teacher.Speciality = vm.Speciality;
            teacher.ExperienceInYear = (byte)vm.ExperienceInYear;

            var result = await _userManager.UpdateAsync(teacher);
            if (!result.Succeeded) throw new Exception(result.Errors.FirstOrDefault().Description);
        }
    }
}
