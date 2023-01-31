

using System;
using System.Threading.Tasks;

using APBD_zad9.Models.DTO;
using APBD_zad9.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zad9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsDatabaseService _databaseService;

        public DoctorsController(IDoctorsDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorsAsync([FromQuery] string idDoctor)
        {
            if (idDoctor == null)
                return Ok(await _databaseService.GetDoctorsAsync());

            var doctor = await _databaseService.GetDoctorAsync(Convert.ToInt32(idDoctor));

            if (doctor == null)
                return NotFound($"Couldn't find doctor with ID {idDoctor}");
            else
                return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorAsync([FromBody] DoctorDto doctorDto)
        {
            if (await _databaseService.DoctorExistsAsync(doctorDto.Email))
                return BadRequest($"Doctor with email '{doctorDto.Email}' already exists");

            await _databaseService.AddDoctorAsync(doctorDto);

            return Ok();
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> EditDoctorAsync([FromRoute] int idDoctor, [FromBody] DoctorDto doctorDto)
        {
            if (!await _databaseService.DoctorExistsAsync(idDoctor))
                return NotFound($"Couldn't find doctor with ID {idDoctor}");

            await _databaseService.EditDoctorAsync(idDoctor, doctorDto);

            return Ok();
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctorAsync([FromRoute] int idDoctor)
        {
            if (!await _databaseService.DoctorExistsAsync(idDoctor))
                return NotFound($"Couldn't find doctor with ID {idDoctor}");

            await _databaseService.DeleteDoctorAsync(idDoctor);

            return Ok();
        }
    }
}