using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_zad11.Models
{
    public class Student
    {
        public Student()
        {
        }

        public Student(int id, string urlToPhoto, string firstName, string lastName, DateTime birthDate, string studies)
        {
            ID = id;
            URLToPhoto = urlToPhoto;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Studies = studies;
        }

        public int ID { get; set; }
        public string URLToPhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Studies { get; set; }
    }
}
