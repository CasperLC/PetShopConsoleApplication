using System.Collections.Generic;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadOwners();

        Owner ReadOwnerById(int id);

        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(Owner owner);

        Owner DeleteOwner(int id);
    }
}