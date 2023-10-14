using HumanFriends.DAL.Interfaces;
using HumanFriends.Domain.Entity;
using HumanFriends.Domain.View;
using HumanFriends.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HumanFriends.Controllers
{
    public class AnimalController : Controller
    {

        private readonly IBaseService<Animal> _animalService;
        private readonly List<TypeAnimal> _typeAnimalRepository;
        private readonly List<ApplicabilityAnimal> _applicabilityAnimalRepository;
        private readonly List<ApplicabilityCommand> _applicabilityCommandRepository;
        private readonly List<Command> _commandRepository;


        public AnimalController(IBaseService<Animal> animalService,
                                IBaseRepository<TypeAnimal> typeAnimalRepository,
                                IBaseRepository<ApplicabilityAnimal> applicabilityAnimalRepository,
                                IBaseRepository<ApplicabilityCommand> applicabilityCommandRepository,
                                IBaseRepository<Command> commandRepository)
        {
            _animalService = animalService;
            _typeAnimalRepository = typeAnimalRepository.GetAll().ToList();
            _applicabilityAnimalRepository = applicabilityAnimalRepository.GetAll().ToList();
            _applicabilityCommandRepository = applicabilityCommandRepository.GetAll().ToList();
            _commandRepository = commandRepository.GetAll().ToList();

        }



        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            var response = await _animalService.GetAnimals();

            if (response.StatusCode == Entity.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Animal animal)
        {
            var response = await _animalService.DeleteAnimal(animal.ID);
            
                return RedirectToAction("GetAnimals");
          
            //return RedirectToAction("Error");
        }



        [HttpGet]
        public IActionResult Save()
        {
            var animalView = new AnimalView();
            var typesAnimal = _typeAnimalRepository;
            var commandsAnimal = _commandRepository;
            animalView.TypeAnimalSelectList = new List<SelectListItem>();


            foreach (var type in typesAnimal)
            {
                animalView.TypeAnimalSelectList.Add(new SelectListItem { Text = type.Name, Value = ""+ type.ID });
            }
            animalView.CommandsAnimalSelect = new List<Command>();

            foreach (var command in commandsAnimal)
            {

                animalView.CommandsAnimalSelect.Add(command);
            }
            animalView.SelectedCommandsAnimalByID = new bool[animalView.CommandsAnimalSelect.Count];
            
            return View(animalView);
        }

        [HttpPost]
        public async Task<IActionResult> Save(AnimalView model)
        {
            Animal animal = new Animal() {
                Name = model.Name
        };
            animal.TypeAnimal = _typeAnimalRepository[model.SelectedTypeAnimal];
            animal.Birthday = model.Birthday;
            

            await _animalService.CreateAnimal(animal);
            return RedirectToAction("GetAnimals");
        }


    }
}
