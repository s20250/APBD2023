
using System.ComponentModel.DataAnnotations;

namespace APBD_zad9.Models
{
    public class Person
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}