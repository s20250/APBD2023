
using APBD_zad9.Models;
using APBD_zad9.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Threading.Tasks;

namespace APBD_zad9.Services
{
	public class DoctorsDatabaseService : IDoctorsDatabaseService
	{
		private readonly DatabaseContext _databaseContext;

		public DoctorsDatabaseService(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
		{
			return await _databaseContext.Doctors
				.Select(doctor => new DoctorDto
				{
					FirstName = doctor.FirstName,
					LastName = doctor.LastName,
					Email = doctor.Email
				}).ToListAsync();
		}

		public async Task<DoctorDto?> GetDoctorAsync(int idDoctor)
		{
			return await _databaseContext.Doctors
				.Where(doctor => doctor.IdDoctor == idDoctor)
				.Select(doctor => new DoctorDto
				{
					FirstName = doctor.FirstName,
					LastName = doctor.LastName,
					Email = doctor.Email
				}).FirstOrDefaultAsync();
		}

		public async Task<bool> DoctorExistsAsync(string email)
		{
			return await _databaseContext.Doctors
				.AnyAsync(doctor => doctor.Email.Equals(email));
		}

		public async Task<bool> DoctorExistsAsync(int idDoctor)
		{
			return await _databaseContext.Doctors
				.AnyAsync(doctor => doctor.IdDoctor.Equals(idDoctor));
		}

		public async Task AddDoctorAsync(DoctorDto payload)
		{
			var doctor = new Doctor
			{
				FirstName = payload.FirstName,
				LastName = payload.LastName,
				Email = payload.Email
			};

			_databaseContext.Doctors.Add(doctor);

			await _databaseContext.SaveChangesAsync();
		}

		public async Task EditDoctorAsync(int idDoctor, DoctorDto payload)
		{
			var doctor = await _databaseContext.Doctors
				.Where(doctor => doctor.IdDoctor == idDoctor)
				.FirstOrDefaultAsync();

			doctor.FirstName = payload.FirstName;
			doctor.LastName = payload.LastName;
			doctor.Email = payload.Email;

			_databaseContext.Doctors.Update(doctor);

			await _databaseContext.SaveChangesAsync();
		}

		public async Task DeleteDoctorAsync(int idDoctor)
		{
			var doctor = new Doctor { IdDoctor = idDoctor };
			
			_databaseContext.Doctors.Attach(doctor);
			_databaseContext.Doctors.Remove(doctor);

			await _databaseContext.SaveChangesAsync();
		}
	}
}