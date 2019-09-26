using System.Collections.Generic;
using System.IO;
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

        public List<Owner> ReadFilteredOwners(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPrPage can not be below 0");
            }

            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _ownerRepo.Count())
            {
                throw new InvalidDataException("Index out of bounds, CurrentPage too high");
            }
            return _ownerRepo.ReadOwners(filter).ToList();
        }

        public Owner ReadOwnerById(int id)
        {
            if (!IdVerifier(id))
            {
                throw new InvalidDataException($"The Id you entered does NOT exist");
            }
            return _ownerRepo.ReadOwnerById(id);
        }

        public Owner CreateOwner(Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                throw new InvalidDataException("Invalid Data: The owner's First Name can't be empty");
            }
            if (string.IsNullOrEmpty(owner.LastName))
            {
                throw new InvalidDataException("Invalid Data: The owner's Last Name can't be empty");
            }
            if (string.IsNullOrEmpty(owner.Address))
            {
                throw new InvalidDataException("Invalid Data: The owner's Address can't be empty");
            }
            if (string.IsNullOrEmpty(owner.Email))
            {
                throw new InvalidDataException("Invalid Data: The owner's Email can't be empty");
            }
            if (string.IsNullOrEmpty(owner.PhoneNumber))
            {
                throw new InvalidDataException("Invalid Data: The owner's Phone Number can't be empty");
            }
            return _ownerRepo.CreateOwner(owner);
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                throw new InvalidDataException("Invalid Data: The owner's First Name can't be empty");
            }
            if (string.IsNullOrEmpty(owner.LastName))
            {
                throw new InvalidDataException("Invalid Data: The owner's Last Name can't be empty");
            }
            if (string.IsNullOrEmpty(owner.Address))
            {
                throw new InvalidDataException("Invalid Data: The owner's Address can't be empty");
            }
            if (string.IsNullOrEmpty(owner.Email))
            {
                throw new InvalidDataException("Invalid Data: The owner's Email can't be empty");
            }
            if (string.IsNullOrEmpty(owner.PhoneNumber))
            {
                throw new InvalidDataException("Invalid Data: The owner's Phone Number can't be empty");
            }
            if (id != owner.id)
            {
                throw new InvalidDataException($"The Id you entered is not the same as the owner's id, you can't change the id");
            }
            return _ownerRepo.UpdateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            if (!IdVerifier(id))
            {
                throw new InvalidDataException($"The Id you entered does NOT exist");
            }
            return _ownerRepo.DeleteOwner(id);
        }

        public bool IdVerifier(int id)
        {
            foreach (var owner in ReadOwners())
            {
                if (id == owner.id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}