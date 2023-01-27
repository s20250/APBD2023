using System.Threading.Tasks;
using APBD_zad4.Models;

namespace APBD_zad4.DBServices

    {
        public interface IAnimalDbService
        {
            List<Animal> GetAnimals(string orderBy);
            void PostAnimal(Animal animal);
            void PutAnimal(int idAnimal, Animal animal);
            void DeleteAnimal(int idAnimal);
        }
    }
