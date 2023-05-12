using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;

namespace PustoKen.Components
{
    public class DiscountBookViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DiscountBookViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = await _context.Books.
                Include(x => x.Genre).
                Include(x => x.Author).
                Include(x => x.BookImages).Where(x => x.DiscountPrice > 0).ToListAsync();
            return View(product);
        }
    }
}
