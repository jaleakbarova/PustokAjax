using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;
using PustoKen.Models;

namespace PustoKen.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public AuthorController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var authors = await _context.Authors.ToListAsync();
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
