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

        public IEnumerable<Owner> ReadOwners(Filter filter)
        {
            if (filter == null)
            {
                return _context.Owners.ToList();
            }

            return _context.Owners
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);

        }

        public int Count()
        {
            return _context.Owners.Count();
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
            //Save PetOwners before attach overrides
            var newOwnerList = new List<PetOwner>(owner.PetOwners);

            //Attach updated owner entity
            _context.Attach(owner).State = EntityState.Modified;

            //Delete old PetOwners with this ownerId
            _context.PetOwners.RemoveRange(
                _context.PetOwners.Where(po=>po.OwnerId==owner.id));

            /*_context.Attach(owner).State = EntityState.Modified;*/
            _context.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
           /* _context.PetOwners.RemoveRange(
                _context.PetOwners.Where(po=>po.OwnerId==id));*/

            var entityRemoved = _context.Remove(new Owner { id = id }).Entity;
            _context.SaveChanges();
            return entityRemoved;
        }
    }
}