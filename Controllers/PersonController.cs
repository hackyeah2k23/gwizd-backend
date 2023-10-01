using Azure;
using GWIZD2023.Models.Domain;
using GWIZD2023.Models.ViewModel;
using GWIZD2023.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GWIZD2023.Controllers
{
    public class PersonController : Controller
    {

        private readonly PersonRepository personRepository;
        private readonly AnimalRepository animalRepository;

        public PersonController(AnimalRepository animalRepository, PersonRepository personRepository)
        {
            this.animalRepository = animalRepository;
            this.personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPersonRequest addPersonRequest)
        {
            //Map view model to domain model
            var person = new Person
            {
                Name = addPersonRequest.Name,
                Surname = addPersonRequest.Surname,
                Email = addPersonRequest.Email,
                Phone = addPersonRequest.Phone,
                ImageData = addPersonRequest.ImageData,
            };
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var persons = await personRepository.GetAllAsync();

            return View(persons);
        }
    }
}
