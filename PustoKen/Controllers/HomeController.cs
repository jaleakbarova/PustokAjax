using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PustoKen.DAL;
using PustoKen.Models;
using PustoKen.ViewModels;
using System.Net;

namespace PustoKen.Controllers
{
    public class HomeController : Controller
    {     
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {              
                Books = await _context.Books.Where(x => x.IsAviable == true).Include(x => x.BookImages).ToListAsync(),                          
            };
            return View(vm);
        }

        public async Task<IActionResult> AddBasket(int id)
        {
            Book book = await _context.Books.FindAsync(id);



            if(book == null)
            {
                return NotFound();
            }

            List<BasketVM> basket = new List<BasketVM>();
            BasketVM basketItem = null;

            if (Request.Cookies["Books"] != null)
            {

                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Books"]);
                basketItem = basket.FirstOrDefault(x => x.BookId == id);

            }

            if (basketItem == null)
            {

                basket.Add(new BasketVM{
                    BookId = id,
                    Count= 1,
                });


            }

            else
            {
                basketItem.Count++;
            }

            Response.Cookies.Append("Books",JsonConvert.SerializeObject(basket));
            return RedirectToAction("Index");   
        }
       
        

    }
}
