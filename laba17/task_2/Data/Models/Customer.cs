namespace PO3_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(80)]
        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; }

        public string CreadtCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
