using Microsoft.AspNetCore.Mvc;
using PustoKen.Models;
namespace PustoKen.ViewModels
{



    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }
        public List<BookImage> BookImages { get; set; }
        public List<Genre> Genres { get; set; }


    }
}
