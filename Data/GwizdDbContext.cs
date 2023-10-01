using GWIZD2023.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GWIZD2023.Data
{
    public class GwizdDbContext : DbContext
    {
        public GwizdDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet <Animal> Animals { get; set;}
    }
}
