
using APBD_zad9.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_zad9.Configurations
{
	public class PrescriptionMedicamentConfig : IEntityTypeConfiguration<PrescriptionMedicament>
	{
		public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
		{
			builder
				.HasKey(prescriptionMedicament => new
				{
					prescriptionMedicament.IdMedicament,
					prescriptionMedicament.IdPrescription
				});
			builder
				.Property(prescriptionMedicament => prescriptionMedicament.Dose)
				.IsRequired(false);
			builder
				.HasOne(prescriptionMedicament => prescriptionMedicament.Prescription)
				.WithMany(prescription => prescription.PrescriptionMedicaments)
				.HasForeignKey(prescriptionMedicament => prescriptionMedicament.IdPrescription);
			builder
				.HasOne(prescriptionMedicament => prescriptionMedicament.Medicament)
				.WithMany(medicament => medicament.PrescriptionMedicaments)
				.HasForeignKey(prescriptionMedicament => prescriptionMedicament.IdMedicament);

			builder.HasData(
					new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "0-0-1" },
					new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 1, Dose = 2, Details = "0-0-1" },
					new PrescriptionMedicament { IdMedicament = 5, IdPrescription = 2, Dose = 3, Details = "1-1-1" },
					new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "1-1-1" }

				);
		}
	}
}