
using System;

using APBD_zad9.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_zad9.Configurations

{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasKey(patient => patient.IdPatient);
            builder
                .Property(patient => patient.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(patient => patient.LastName)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(patient => patient.Birthdate)
                .IsRequired();

            builder.HasData(
            new Patient { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", Birthdate = Convert.ToDateTime("1991-06-23") },
            new Patient { IdPatient = 2, FirstName = "Adam", LastName = "Nowak", Birthdate = Convert.ToDateTime("1980-12-30") },
            new Patient { IdPatient = 3, FirstName = "Janina", LastName = "Kowalska", Birthdate = Convert.ToDateTime("2015-12-10") },
            new Patient { IdPatient = 4, FirstName = "Adrianna", LastName = "Nowak", Birthdate = Convert.ToDateTime("190-09-09") }
            );
            
        }
    }
}