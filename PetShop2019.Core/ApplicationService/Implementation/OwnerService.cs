using System.Collections.Generic;
using System.Linq;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.ApplicationService.Implementation
{
    public class OwnerService: IOwnerService
    {
        private readonly IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }


        public List<Owner> ReadOwners()
        {
            return _ownerRepo.ReadOwners().ToList();
        }

        public Owner ReadOwnerById(int id)
        {
            return _ownerRepo.ReadOwnerById(id);
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            if (id == owner.id)
            {
                return _ownerRepo.UpdateOwner(owner);
            }

            return null;
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.DeleteOwner(id);
        }
    }
}