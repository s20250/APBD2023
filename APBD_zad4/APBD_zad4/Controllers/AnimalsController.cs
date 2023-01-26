using Microsoft.AspNetCore.Mvc;

namespace APBD_zad4;

public class Animals : Controller
{
   
   private static List<Animal> _animal = new List<Animal>()
   {
       // new Student("x", "y", 100, new DateTime(1990, 9, 20), "studia", "tryb", "email", "ojciec", "matka"),
       // new Student("x2", "y2", 101, new DateTime(1991, 9, 20), "studia1", "tryb1", "email1", "ojciec1", "matka1")
   };
   
   [HttpGet]
   public IEnumerable<Animal> Get()
   {
      return _animal;
   }
}