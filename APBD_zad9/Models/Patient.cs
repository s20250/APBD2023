
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APBD_zad9.Models
{
    public class Patient : Person
    {
        public Patient(int idPatient, DateTime birthdate, ICollection<Prescription> prescriptions)
        {
            IdPatient = idPatient;
            Birthdate = birthdate;
            Prescriptions = prescriptions;
        }

        public int IdPatient { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}