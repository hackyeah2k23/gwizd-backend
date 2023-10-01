using GWIZD2023.Models.Domain;

namespace GWIZD2023.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> GetAsync(Guid id);
        Task<Person> AddAsync(Person person);
        Task<Person?> UpdateAsync(Person person);
        Task<Person?> DeleteAsync(Guid id);
    }
}
