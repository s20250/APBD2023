
using System;
using System.Collections.Generic;

namespace APBD_zad9.Models.DTO

{
    public class PrescriptionDto
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public DoctorDto Doctor { get; set; }
        public PatientDto Patient { get; set; }
        public IEnumerable<MedicamentDto> Medicaments { get; set; }
    }
}