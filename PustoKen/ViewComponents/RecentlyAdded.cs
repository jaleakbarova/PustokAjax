using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;

namespace PustoKen.Components
{
    public class RecentlyAddedViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public RecentlyAddedViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var product = await _context.Books.
                Include(x=>x.BookImages).
                Include(x => x.Genre).
                Include(x => x.Author).
                Where(x => x.IsAviable==true).OrderByDescending(x=>x.Id==id).ToListAsync();
            return View(product);
        }
    }
}
