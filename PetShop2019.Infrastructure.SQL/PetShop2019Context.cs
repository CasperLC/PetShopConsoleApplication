using Microsoft.EntityFrameworkCore;
using PetShop2019.Core.Entities;

namespace PetShop2019.Infrastructure.SQL
{
    public class PetShop2019Context: DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public PetShop2019Context(DbContextOptions options):base(options)
        {

        }
    }
}