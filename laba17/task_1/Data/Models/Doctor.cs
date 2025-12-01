namespace PO1_HpspitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Doctor
    {
        public int DoctorId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Specialty { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}
