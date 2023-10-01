using Azure;
using GWIZD2023.Data;
using GWIZD2023.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GWIZD2023.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly GwizdDbContext gvizdDbContext;

        public AnimalRepository(GwizdDbContext gwizdDbContext)
        {
            this.gvizdDbContext = gwizdDbContext;
        }

        public async Task<Animal> AddAsync(Animal animal)
        {
            await gvizdDbContext.Animals.AddAsync(animal);
            await gvizdDbContext.SaveChangesAsync();
            return animal;
        }

        public Task<Animal?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
           return await gvizdDbContext.Animals.ToListAsync();
        }

        public async Task<Animal?> GetAsync(Guid id)
        {
            return await gvizdDbContext.Animals.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Animal?> UpdateAsync(Animal animal)
        {
            var existingAnimal = await gvizdDbContext.Animals.FindAsync(animal.Id);
            if (existingAnimal != null)
            {
                existingAnimal.Location = animal.Location;
                existingAnimal.Date = animal.Date;
                existingAnimal.Color = animal.Color;
                existingAnimal.Wild = animal.Wild;
                existingAnimal.Details = animal.Details;
                existingAnimal.ImageData = animal.ImageData;
                existingAnimal.Found = animal.Found;
                existingAnimal.Lost = animal.Lost;
                existingAnimal.TypeOfAnimal = animal.TypeOfAnimal;
                existingAnimal.Breed = animal.Breed;
                await gvizdDbContext.SaveChangesAsync();
                return existingAnimal;
            }
            return null;
        }
    }
}
