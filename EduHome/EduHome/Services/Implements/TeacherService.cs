using EduHome.Extensions;
using EduHome.Models;
using EduHome.Models.BaseModels;
using EduHome.Services.Interfaces;
using EduHome.ViewModels.User;
using Microsoft.AspNetCore.Identity;

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
            if (!result.Succeeded) throw new Exception("Register user failed!");

            result = await _userManager.AddToRoleAsync(user, "Student");
            if (!result.Succeeded) throw new Exception("Add role failed!");
        }
    }
}
