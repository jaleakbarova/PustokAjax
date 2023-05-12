using Microsoft.AspNetCore.Mvc;
using PustoKen.DAL;

using PustoKen.ViewModels;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PustoKen.Models;

namespace PustoKen.ViewComponents
{
    public class BasketViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public BasketViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<BasketVM>? basketBooks = new List<BasketVM>();

            if (Request.Cookies["Books"] != null)
            {
                basketBooks = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Books"]);
            }

            List<BasketItemVm> basketItems = new List<BasketItemVm>();
            
            foreach(var item in basketBooks)
            {
                Book book = await _context.Books.Include(x=>x.BookImages).FirstOrDefaultAsync(x => x.Id == item.BookId);

                if (book != null)
                {
                    basketItems.Add(new BasketItemVm
                    {

                        BookId=book.Id,
                        Name=book.Name,
                        Image=book.BookImages.FirstOrDefault(x=>x.IsMain==true).Image,
                        Price=book.Price,
                        BookCount=item.Count

                    });
                }
            }
            return View(basketItems);
        }
    }
}
