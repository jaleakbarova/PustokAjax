using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;

namespace PustoKen.Components
{
    public class TopRatedViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public TopRatedViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var product = await _context.Books.
                Include(x => x.BookImages).
                Include(x => x.Genre).
                Include(x => x.Author).
                Where(x => x.IsAviable == true).OrderBy(x => Guid.NewGuid()).ToListAsync();
            return View(product);
        }
    }
}
