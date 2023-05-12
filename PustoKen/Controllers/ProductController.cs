using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PustoKen.DAL;
using PustoKen.Models;
using PustoKen.ViewModels;

namespace PustoKen.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;


        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Cart()
        {
            List<BasketVM>? basketBooks = new List<BasketVM>();

            if (Request.Cookies["Books"] != null)
            {
                basketBooks = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Books"]);
            }

            List<BasketItemVm> basketItems = new List<BasketItemVm>();

            foreach (var item in basketBooks)
            {
                Book book =  _context.Books.Include(x => x.BookImages).FirstOrDefault(x => x.Id == item.BookId);

                if (book != null)
                {
                    basketItems.Add(new BasketItemVm
                    {

                        BookId = book.Id,
                        Name = book.Name,
                        Image = book.BookImages.FirstOrDefault(x => x.IsMain == true).Image,
                        Price = book.Price,
                        BookCount = item.Count

                    });
                }
            }
            return View(basketItems);           
        }


        public async Task<IActionResult> Increment(int id)
        {
            List<BasketVM>? basketBooks= JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Books"]);
            BasketVM bookVm= basketBooks.Find(x => x.BookId == id);

            bookVm.Count++;

            Response.Cookies.Append("Books", JsonConvert.SerializeObject(basketBooks));
            return RedirectToAction("Cart");
        }
        public async Task<IActionResult> Decrement(int id)
        {
            List<BasketVM>? basketBooks = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Books"]);
            BasketVM bookVm = basketBooks.Find(x => x.BookId == id);
            if (bookVm.Count != 1)
            {
                bookVm.Count--;

            }
            else
            {
                basketBooks.Remove(bookVm);
            }

                Response.Cookies.Append("Books", JsonConvert.SerializeObject(basketBooks));
                return RedirectToAction("Cart");

        }

        


    }
}
