using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop2019.Infrastructure.SQL.Repositories
{
    public class PetRepository: IPetRepository
    {
        private PetShop2019Context _context;

        public PetRepository(PetShop2019Context context)
        {
            _context = context;
        }
        public IEnumerable<Pet> ReadPets()
        {
            return _context.Pets.ToList();
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.FirstOrDefault(p => p.ID == id);
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
            throw new System.NotImplementedException();
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