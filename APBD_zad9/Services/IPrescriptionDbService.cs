
using System.Collections.Generic;
using System.Threading.Tasks;
using APBD_zad9.Models;
using APBD_zad9.Models.DTO;

namespace APBD_zad9.Services
{
    public interface IPrescriptionsDatabaseService
    {
        Task<IEnumerable<PrescriptionDto>> GetPrescriptionsAsync();
        Task<PrescriptionDto?> GetPrescriptionAsync(int idPrescription);
    }
}