using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        private PetShop2019Context _context;

        public OwnerRepository(PetShop2019Context context)
        {
            _context = context;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _context.Owners.ToList();
        }

        public Owner ReadOwnerById(int id)
        {
            return _context.Owners
                .Include(o => o.PetOwners)
                .ThenInclude(po => po.Pet)
                .FirstOrDefault(o => o.id == id);
        }

        public Owner CreateOwner(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Modified;
            _context.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerToRemove = _context.Owners.FirstOrDefault(o => o.id == id);
            _context.Remove(ownerToRemove);
            _context.SaveChanges();
            return ownerToRemove;
        }
    }
}