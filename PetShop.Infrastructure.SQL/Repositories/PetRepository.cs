using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using Microsoft.EntityFrameworkCore;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class PetRepository: IPetRepository
    {
        private PetShop2019Context _context;

        public PetRepository(PetShop2019Context context)
        {
            _context = context;
        }
        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            if (filter == null)
            {
                return _context.Pets.ToList();
            }

            return _context.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);

        }

        public int Count()
        {
            return _context.Pets.Count();
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.FirstOrDefault(p => p.ID == id);
        }

        public Pet ReadByIdWithOwner(int id)
        {
            return _context.Pets
                .Include(p => p.PetOwners).ThenInclude(po => po.Owner)
                .FirstOrDefault(p => id == p.ID);
        }

        public Pet CreatePet(Pet pet)
        {
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;

            /*var productToCreate = _context.Pets.Add(pet).Entity;
            _context.SaveChanges();
            return productToCreate;*/
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            //Clone pet owners to avoid override on attach
            var newPetOwners = new List<PetOwner>(petUpdate.PetOwners);

            //Attach basic properties
            _context.Attach(petUpdate).State = EntityState.Modified;

            //Remove old POs
            _context.PetOwners.RemoveRange(
                _context.PetOwners.Where(po => po.PetId == petUpdate.ID)
                );

            //Save
            _context.SaveChanges();

            return petUpdate;
        }

        public Pet DeletePet(int id)
        {
            var entityRemoved = _context.Remove(new Pet {ID = id}).Entity;
            _context.SaveChanges();
            return entityRemoved;

            /*var toRemove = _context.Pets.FirstOrDefault(p => p.ID == id);
            _context.Pets.Remove(toRemove);
            _context.SaveChanges();
            return toRemove*/
        }
    }
}