

using System;

using APBD_zad9.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_zad9.Configurations
{
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder
                .HasKey(prescription => prescription.IdPrescription);
            builder
                .Property(prescription => prescription.Date)
                .IsRequired();
            builder
                .Property(prescription => prescription.DueDate)
                .IsRequired();
            builder
                .HasOne(prescription => prescription.Patient)
                .WithMany(patient => patient.Prescriptions)
                .HasForeignKey(prescription => prescription.IdPatient);
            builder
                .HasOne(prescription => prescription.Doctor)
                .WithMany(doctor => doctor.Prescriptions)
                .HasForeignKey(prescription => prescription.IdDoctor);

            builder.HasData(
                new Prescription { IdPrescription = 1, Date = Convert.ToDateTime("2023-01-01"), DueDate = Convert.ToDateTime("2023-01-01"), IdPatient = 1, IdDoctor = 1 },
                new Prescription { IdPrescription = 2, Date = Convert.ToDateTime("2023-01-01"), DueDate = Convert.ToDateTime("2023-01-01"), IdPatient = 2, IdDoctor = 2 },
                new Prescription { IdPrescription = 3, Date = Convert.ToDateTime("2023-01-01"), DueDate = Convert.ToDateTime("2023-01-01"), IdPatient = 3, IdDoctor = 3 },
                new Prescription { IdPrescription = 4, Date = Convert.ToDateTime("2023-01-01"), DueDate = Convert.ToDateTime("2023-01-01"), IdPatient = 4, IdDoctor = 4 },
                new Prescription { IdPrescription = 5, Date = Convert.ToDateTime("2023-01-01"), DueDate = Convert.ToDateTime("2023-01-01"), IdPatient = 5, IdDoctor = 5 }
            );
        }
    }
}