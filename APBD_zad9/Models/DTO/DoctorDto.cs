

using System.ComponentModel.DataAnnotations;

namespace APBD_zad9.Models.DTO
{
    public class DoctorDto : Person
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}