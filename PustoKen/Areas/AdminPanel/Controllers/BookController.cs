using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;
using PustoKen.Models;
using PustoKen.Utilities.Extension;

namespace PustoKen.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public BookController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public async Task<IActionResult> Index()
        {
            var procedur = await _context.Books.Include(x => x.Author).Include(x => x.Genre).ToListAsync();
            return View(procedur);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors=_context.Authors.ToList();
            ViewBag.Genres=_context.Genres.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!book.MainFile.CheckFileType("image"))
            {
                ModelState.AddModelError("Image", "File type must be image ");
            }
            if (book.MainFile.CheckFileSize(2000))
            {
                ModelState.AddModelError("Image", "File must be less than 2000 kb ");
            }

            book.BookImages=new List<BookImage>();

            book.BookImages.Add(new BookImage
            {
                IsMain = true,
                Image = await book.MainFile.SaveFileAsync(_environment.WebRootPath, "assets/image/bg-images"),
                Book = book
            });

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();   

            return RedirectToAction(nameof(Index));

        }
    }
}
