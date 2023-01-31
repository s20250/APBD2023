
using System.Numerics;
using APBD_zad9.Configurations;
using Microsoft.EntityFrameworkCore;

namespace APBD_zad9.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbSet<Doctor> doctors, DbSet<Medicament> medicaments, DbSet<Patient> patients, DbSet<Prescription> prescriptions, DbSet<PrescriptionMedicament> prescriptionMedicaments)
        {
            Doctors = doctors;
            Medicaments = medicaments;
            Patients = patients;
            Prescriptions = prescriptions;
            PrescriptionMedicaments = prescriptionMedicaments;
        }

        public DatabaseContext(DbContextOptions options, DbSet<Doctor> doctors, DbSet<Medicament> medicaments, DbSet<Patient> patients, DbSet<Prescription> prescriptions, DbSet<PrescriptionMedicament> prescriptionMedicaments) : base(options)
        {
            Doctors = doctors;
            Medicaments = medicaments;
            Patients = patients;
            Prescriptions = prescriptions;
            PrescriptionMedicaments = prescriptionMedicaments;
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentConfig());
        }
    }
}