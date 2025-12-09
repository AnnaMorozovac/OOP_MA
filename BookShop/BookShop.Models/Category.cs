using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<BookCategory> CategoryBooks { get; set; } = new HashSet<BookCategory>();
    }
}
