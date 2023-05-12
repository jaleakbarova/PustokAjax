using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Hosting;
using PustoKen.DAL;
using PustoKen.Models;
using PustoKen.Utilities.Extension;
using System;
using System.IO;

namespace PustoKen.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;


        private readonly IWebHostEnvironment _environment;
        public SliderController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View(slider);
            if (!slider.ImageFile.CheckFileType("image/"))
            {
                ModelState.AddModelError("ImageFile", "File must be image format");
                return View();
            }
            if (slider.ImageFile.CheckFileSize(200))
            {
                ModelState.AddModelError("ImageFile", "File must be less than 200Kb");
                return View();

            }

            slider.Image = await slider.ImageFile.SaveFileAsync(_environment.WebRootPath, "assets/image/bg-images");
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Slider slider)
        {
            Slider? exists = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == slider.Id);

            if (exists == null)
            {
                ModelState.AddModelError("", "Slider not found");
                return View(slider);
            }

            if (slider.ImageFile != null)
            {
                if (!slider.ImageFile.CheckFileType("image"))
                {
                    ModelState.AddModelError("ImageFile", "File must be image format");
                    return View();
                }
                if (slider.ImageFile.CheckFileSize(200))
                {
                    ModelState.AddModelError("ImageFile", "File must be less than 200kb");
                    return View();
                }
                exists.Image = await slider.ImageFile.SaveFileAsync(
                    _environment.WebRootPath, "bg-images"); 
            }

                exists.Title1 = slider.Title1;
                exists.Title2 = slider.Title2;
                exists.Description = slider.Description;
                exists.Image = slider.Image;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));       
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            Slider? exist = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                ModelState.AddModelError("", "Invalid input");
            }

            _context.Sliders.Remove(exist);
            await _context.SaveChangesAsync();
            //return RedirectToAction("Index");
            return ViewComponent("Slider");
        }
    }

}

