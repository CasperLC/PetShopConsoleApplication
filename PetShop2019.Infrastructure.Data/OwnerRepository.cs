using System.Collections.Generic;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop2019.Infrastructure.Data
{
    public class OwnerRepository: IOwnerRepository
    {
        private static FakeDB fakeDB = new FakeDB();
        private static int id;

        public IEnumerable<Owner> ReadOwners()
        {
            return fakeDB.OwnerList;
        }

        public Owner ReadOwnerById(int id)
        {
            foreach (var owner in fakeDB.OwnerList)
            {
                if (owner.id.Equals(id))
                {
                    return owner;
                }
            }

            return null;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.id = id;
            fakeDB.OwnerList.Add(owner);
            id++;
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var currentOwner = ReadOwnerById(owner.id);
            if (currentOwner != null)
            {
                currentOwner.FirstName = owner.FirstName;
                currentOwner.LastName = owner.LastName;
                currentOwner.Address = owner.Address;
                currentOwner.PhoneNumber = owner.PhoneNumber;
                currentOwner.Email = owner.Email;
                return currentOwner;
            }

            return null;
        }

        public Owner DeleteOwner(int id)
        {
            Owner tempOwner = null;
            foreach (var owner in fakeDB.OwnerList)
            {
                if (owner.id == id)
                {
                    tempOwner = owner;
                }
            }

            fakeDB.OwnerList.Remove(tempOwner);
            return tempOwner;
        }
    }
}