
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_zad9.Models;
using APBD_zad9.Models.DTO;

using Microsoft.EntityFrameworkCore;

namespace APBD_zad9.Services
{
	public class PrescriptionsDatabaseService : IPrescriptionsDatabaseService
	{
		private readonly DatabaseContext _databaseContext;

		public PrescriptionsDatabaseService(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAsync()
		{
			return await _databaseContext.Prescriptions
				.Select(prescription => new PrescriptionDto
				{
					Date = prescription.Date,
					DueDate = prescription.DueDate,
					Doctor = new DoctorDto
					{
						FirstName = prescription.Doctor.FirstName,
						LastName = prescription.Doctor.LastName,
						Email = prescription.Doctor.Email
					},
					Patient = new PatientDto
					{
						FirstName = prescription.Patient.FirstName,
						LastName = prescription.Patient.LastName,
						Birthdate = prescription.Patient.Birthdate
					},
					Medicaments = prescription.PrescriptionMedicaments
						.Select(prescriptionMedicament => new MedicamentDto
						{
							Name = prescriptionMedicament.Medicament.Name,
							Description = prescriptionMedicament.Medicament.Description,
							Type = prescriptionMedicament.Medicament.Type,
							Dose = prescriptionMedicament.Dose,
							Details = prescriptionMedicament.Details,
						})
				})
				.ToListAsync();
		}

		public async Task<PrescriptionDto?> GetPrescriptionAsync(int idPrescription)
		{
			return await _databaseContext.Prescriptions
				.Where(prescription => prescription.IdPrescription == idPrescription)
				.Select(prescription => new PrescriptionDto
				{
					Date = prescription.Date,
					DueDate = prescription.DueDate,
					Doctor = new DoctorDto
					{
						FirstName = prescription.Doctor.FirstName,
						LastName = prescription.Doctor.LastName,
						Email = prescription.Doctor.Email
					},
					Patient = new PatientDto
					{
						FirstName = prescription.Patient.FirstName,
						LastName = prescription.Patient.LastName,
						Birthdate = prescription.Patient.Birthdate
					},
					Medicaments = prescription.PrescriptionMedicaments
						.Select(prescriptionMedicament => new MedicamentDto
						{
							Name = prescriptionMedicament.Medicament.Name,
							Description = prescriptionMedicament.Medicament.Description,
							Type = prescriptionMedicament.Medicament.Type,
							Dose = prescriptionMedicament.Dose,
							Details = prescriptionMedicament.Details,
						})
				}).FirstOrDefaultAsync();
		}
	}
}