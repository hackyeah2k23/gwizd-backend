using GWIZD2023.Data;
using GWIZD2023.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GWIZD2023.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly GwizdDbContext personContext;

        public PersonRepository(GwizdDbContext personContext)
        {
            this.personContext = personContext;
        }

        public async Task<Person> AddAsync(Person person)
        {
            await personContext.AddAsync(person);
            await personContext.SaveChangesAsync();
            return person;
        }

        public async Task<Person?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await personContext.Persons.Include(x => x.Animals).ToListAsync();
        }

        public Task<Person?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> UpdateAsync(Person person)
        {
            var existingPerson = await personContext.Persons.FindAsync(person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Surname = person.Surname;
                existingPerson.ImageData= person.ImageData;
                existingPerson.Email = person.Email;
                existingPerson.Phone = person.Phone;
                return existingPerson;
            }
            return null;
        }
    }
}
