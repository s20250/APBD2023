using System.Numerics;
using System.Reflection.Emit;
using APBD_zad9.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_zad9.Configurations{
    
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasKey(doctor => doctor.IdDoctor);
            builder
                .Property(doctor => doctor.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(doctor => doctor.LastName)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(doctor => doctor.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jan@gmail.com" },
                new Doctor { IdDoctor = 2, FirstName = "Adam", LastName = "Nowak", Email = "adam@gmail.com" },
                new Doctor { IdDoctor = 3, FirstName = "Zdzislaw", LastName = "Kowal", Email = "zdzislaw@gmail.com" }
            );
        }
    }
}