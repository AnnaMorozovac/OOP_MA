namespace BookShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    public class Author
    {
        public int AuthorId { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
