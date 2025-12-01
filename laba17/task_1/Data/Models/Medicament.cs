namespace PO1_HpspitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Medicament
    {
        public int MedicamentId { get; set;}

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
