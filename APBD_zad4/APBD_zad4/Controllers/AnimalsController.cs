using APBD_zad4.DBServices;
using APBD_zad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zad4
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalDbService _animalDbService;

        public AnimalsController(IAnimalDbService animalsDbService)
        {
            _animalDbService = animalsDbService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAnimals([FromQuery] string orderBy)
        {
            List<Animal> animals = null;
            try
            {
                animals = _animalDbService.GetAnimals(orderBy);}
            catch (Exception) { return NotFound("You can order by name, description, category or area"); }
            return Ok(animals);
        }

        [HttpPost]
        public async Task<IActionResult> PostAnimal(Animal animal)
        {
            try { _animalDbService.PostAnimal(animal); }
            catch (Exception) { return BadRequest("Data are not valid"); }
            return Ok("Animal created");
        }

        [HttpPut("{idAnimal}")]
        public async Task<IActionResult> PutAnimal(int idAnimal, Animal animal)
        {
            try
            {
                _animalDbService.PutAnimal(idAnimal, animal);
            }
            catch (Exception){}

            return Ok("Animal changed");

        }


        [HttpDelete("{idAnimal}")]
        public async Task<IActionResult> DeleteAnimal(int idAnimal)
        {
            try
            {
                _animalDbService.DeleteAnimal(idAnimal);
            }
            catch (Exception) {}
        
        return Ok("Animal deleted");
        }
        
    }
}