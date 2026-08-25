using EduHome.Contexts;
using EduHome.Enums;
using EduHome.Extensions;
using EduHome.Models;
using EduHome.Services.Interfaces;
using EduHome.ViewModels.Slider;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Services.Implements
{
    public class SliderService : ISliderService
    {
        //injection
        readonly NajibaContext _context;
        readonly IWebHostEnvironment _env;

        public SliderService(NajibaContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Create(SliderCreateVM vm)
        {
            if (!vm.Image.IsSizeValid(1, FileSize.MB)) throw new Exception("Size is not valid");
            if (!vm.Image.IsFormatValid()) throw new Exception("Format is not valid!");

            var slider = new Slider
            {
                Title = vm.Title, //Test title
                Text = vm.Text, //Some text
                Image = vm.Image.UploadFile(_env.WebRootPath, "images/slider"), //najiba.png
                CreatedAt = DateTime.UtcNow.AddHours(4)
            };

            var entry = _context.sliders.Add(slider);
            if (entry.State != EntityState.Added) throw new Exception("Add Failed!"); //db-de insert emri islemeyecek
            var count = _context.SaveChanges();
            if (count <= 0) throw new Exception("Save slider failed!");
        }
    }
}
//ChangeTracker, yalniz read emeliyyatlarinda bloklayiriq, ACID, A - atomicity, concurrency, isolation, durability