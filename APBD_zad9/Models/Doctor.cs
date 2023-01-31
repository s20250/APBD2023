
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APBD_zad9.Models
{
    public class Doctor : Person
    {
        public int IdDoctor { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}