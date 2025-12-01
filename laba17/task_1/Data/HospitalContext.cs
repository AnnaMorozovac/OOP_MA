namespace PO1_HpspitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using PO1_HpspitalDatabase.Data.Models;
    class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=HospitalDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>().HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament).WithMany(m => m.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);
        }
    }
}
