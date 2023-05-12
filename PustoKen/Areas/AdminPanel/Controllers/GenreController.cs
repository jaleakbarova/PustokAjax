using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;
using PustoKen.Models;

namespace PustoKen.Areas.AdminPanel.Controllers
{
        [Area("AdminPanel")]
    public class GenreController : Controller
    {
        
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _environment;
            public GenreController(AppDbContext context, IWebHostEnvironment environment)
            {
                _context = context;
                _environment = environment;
            }
            public async Task<IActionResult> Index()
            {
                return View(await _context.Genres.ToListAsync());
            }

            public async Task<IActionResult> Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Genre genre)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var genres = await _context.Genres.ToListAsync();
                await _context.Genres.AddAsync(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

    }

