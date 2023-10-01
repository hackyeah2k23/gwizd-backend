using GWIZD2023.Models.Domain;
using GWIZD2023.Models.ViewModel;
using GWIZD2023.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWIZD2023.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalApiController : ControllerBase
    {
        private readonly IAnimalRepository animalRepository;

        public AnimalApiController(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await animalRepository.GetAllAsync();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimal(Guid id)
        {
            var animal = await animalRepository.GetAsync(id);

            if (animal != null)
            {
                return Ok(animal);
            }

            return NotFound(); // Jeśli nie znaleziono zwierzęcia
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal([FromBody]AddAnimalRequest addAnimalRequest)
        {
            // Przekształć dane z AddAnimalRequest na model Animal
            Console.WriteLine("test");
            var animal = new Animal
            {
                Breed = addAnimalRequest.Breed,
                TypeOfAnimal = addAnimalRequest.TypeOfAnimal,
                Color = addAnimalRequest.Color,
                Date = addAnimalRequest.Date,
                Details = addAnimalRequest.Details,
                Found = addAnimalRequest.Found,
                Location = addAnimalRequest.Location,
                Lost = addAnimalRequest.Lost,
                Wild = addAnimalRequest.Wild,
                // Przekształć dane Base64 na byte[]
                ImageData = addAnimalRequest.ImageData
            };

            await animalRepository.AddAsync(animal);

            // Tutaj  zwrócić odpowiedź z ID utworzonego zwierzęcia
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(Guid id, EditAnimalRequest editAnimalRequest)
        {
            var animal = await animalRepository.GetAsync(id);

            if (animal == null)
            {
                return NotFound(); // Jeśli nie znaleziono zwierzęcia o podanym ID
            }

            // Aktualizuj dane zwierzęcia na podstawie danych z editAnimalRequest
            animal.Breed = editAnimalRequest.Breed;
            animal.TypeOfAnimal = editAnimalRequest.TypeOfAnimal;
            animal.Color = editAnimalRequest.Color;
            animal.Date = editAnimalRequest.Date;
            animal.Details = editAnimalRequest.Details;
            animal.Found = editAnimalRequest.Found;
            animal.Location = editAnimalRequest.Location;
            animal.Lost = editAnimalRequest.Lost;
            animal.Wild = editAnimalRequest.Wild;
            // Przypisz dane Base64 do ImageData
            animal.ImageData = editAnimalRequest.ImageData;

            await animalRepository.UpdateAsync(animal);

            return NoContent(); // Zwierzęcie zaktualizowane
        }
    }
}


