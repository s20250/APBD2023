using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zad3.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    // private static List<Student> _students = new List<Student>()
    // {
    //     // new Student("x", "y", 100, new DateTime(1990, 9, 20), "studia", "tryb", "email", "ojciec", "matka"),
    //     // new Student("x2", "y2", 101, new DateTime(1991, 9, 20), "studia1", "tryb1", "email1", "ojciec1", "matka1")
    // };
    
    // [HttpGet]
    // public IEnumerable<Student> Get()
    // {
    //     return _students;
    // }
    
    // [HttpGet]
    // [Route("{studentId:int}")]
    // public IActionResult GetStudent(int studentId)
    // {
    //     Student student = _students.First(student => student.IndexNo == studentId);
    //
    //     return Ok(student);
    // }

    
    
    private static List<Student> _students = new List<Student>();

    [HttpGet]
    public IActionResult Get()
    {
        CSVfile.ReadCSV(_students);
        return Ok(_students);
    }
    
    [HttpGet]
    [Route("{studentId:int}")]
    public IActionResult GetStudent(int studentId)
    {
        CSVfile.ReadCSV(_students);
        Student student = _students.First(student => student.IndexNo == studentId);

        return Ok(student);
    }

    [HttpPut]
    [Route("{studentId:int}")]
    public IActionResult PutStudent(int studentId, Student newStudent)
    {
        int studentIndex = _students.FindIndex(student => student.IndexNo == studentId);

        if (studentIndex != -1)
        {
            _students[studentIndex] = newStudent;
        }


        return Ok(newStudent);
    }


    [HttpPost]
    public IActionResult PostStudent(Student student)
    {
        bool indexNoExists = CheckIndexNoValidity(student.IndexNo);

        if (indexNoExists)
        {
            return BadRequest("Index No already exists");
        }
        string returnCode = CheckStudentDataValid(student);
        if (string.IsNullOrEmpty(returnCode))

        {
            _students.Add(student);
            return Ok(student);
        }
        
        return BadRequest(returnCode);
    }

    private bool CheckIndexNoValidity(int studentIndexNo)
    {
        return _students.Exists(s => s.IndexNo == studentIndexNo);
    }

    private string CheckStudentDataValid(Student student)
    {
        if (string.IsNullOrEmpty(student.Name))
        {
            return "Name incorrect";
        }

        if (string.IsNullOrEmpty(student.Surname))
        {
            return "Surname incorrect";
        }

        if (string.IsNullOrEmpty(student.Birthdate.ToString()))
        {
            return "Date incorrect";
        }

        if (string.IsNullOrEmpty(student.Kierunek))
        {
            return "kioerunek incorretc";
        }

        if (string.IsNullOrEmpty(student.Tryb))
        {
            return "tryb incorrect";
        }

        if (string.IsNullOrEmpty(student.Email))
        {
            return "email incorrect";
        }

        if (string.IsNullOrEmpty(student.ImieOjca))
        {
            return "imie ojcja icorrect";
        }

        if (string.IsNullOrEmpty(student.ImieMatki))
        {
            return "imie matki incorrect";
        }

        return string.Empty;
    }

    [HttpDelete]
    [Route("{studentId:int}")]
    public IActionResult DeleteStudent(Student student)
    {
        bool indexNoExists = CheckIndexNoValidity(student.IndexNo);

        if (indexNoExists)
        {

            _students.Remove(student);
            return Ok(student);

        }

        {
            return BadRequest("Index No doesn't exists");
        }
        
      

    }
    
}