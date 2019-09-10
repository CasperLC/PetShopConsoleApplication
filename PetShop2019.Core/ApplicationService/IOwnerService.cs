using System.Collections.Generic;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> ReadOwners();

        Owner ReadOwnerById(int id);

        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(int id, Owner owner);

        Owner DeleteOwner(int id);
    }
}