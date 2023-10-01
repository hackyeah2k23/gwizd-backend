using GWIZD2023.Models.Domain;

namespace GWIZD2023.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal?> GetAsync(Guid id);
        Task<Animal> AddAsync(Animal lostAnimal);
        Task<Animal?> UpdateAsync(Animal lostAnimal);
        Task<Animal?> DeleteAsync(Guid id);
    }
}

