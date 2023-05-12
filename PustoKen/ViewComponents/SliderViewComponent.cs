using Microsoft.AspNetCore.Mvc;
using PustoKen.DAL;

namespace PustoKen.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
