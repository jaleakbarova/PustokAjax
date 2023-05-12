namespace PustoKen.Models
{
    public class Genre

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Genre>? Genres { get; set; }

    }

}
