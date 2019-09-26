using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using PetShop2019.Core.Entities;

namespace PetShop.Infrastructure.SQL
{
    public class PetShop2019Context: DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }

        public PetShop2019Context(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetOwner>()
                .HasKey(po => new
                {
                    po.OwnerId,
                    po.PetId
                });

            modelBuilder.Entity<PetOwner>()
                .HasOne(po => po.Owner)
                .WithMany(o => o.PetOwners)
                .HasForeignKey(po => po.OwnerId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PetOwner>()
                .HasOne(po => po.Pet)
                .WithMany(p => p.PetOwners)
                .HasForeignKey(po => po.PetId).OnDelete(DeleteBehavior.SetNull);

            
        }
    }
}