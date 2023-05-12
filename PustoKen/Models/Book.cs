using System.ComponentModel.DataAnnotations.Schema;

namespace PustoKen.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public decimal Rate { get; set; }
        public bool IsAviable { get; set; }
        public decimal Price { get; set; }
        public double DiscountPrice { get; set; }
        public int PageCount { get; set; }
        public string? Description { get; set; }
        public ICollection <BookImage>?BookImages{ get; set; }
        [NotMapped]
        public List<IFormFile>? Files { get; set; }
        [NotMapped]
        public IFormFile MainFile { get; set; }


    }
}
