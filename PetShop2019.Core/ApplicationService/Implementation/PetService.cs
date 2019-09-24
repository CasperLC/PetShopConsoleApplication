using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.ApplicationService.Implementation
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }
        public List<Pet> GetPets()
        {
            List<Pet> listOfPets = _petRepo.ReadPets().ToList();

            return listOfPets;
        }

        public List<Pet> GetPetsByType(string type)
        {
            List<Pet> temp = new List<Pet>();
            foreach (var pet in _petRepo.ReadPets().ToList())
            {
                if (pet.Type.ToLower().Equals(type.ToLower()))
                {
                    temp.Add(pet);
                }
            }

            return temp;
        }

        public Pet CreatePet(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                throw new InvalidDataException("Invalid Data: The Pet's name can NOT be empty");
            }
            if (string.IsNullOrEmpty(pet.Type))
            {
                throw new InvalidDataException("Invalid Data: The Pet's type can NOT be empty");
            }

            DateTime tempBirthdate = pet.Birthdate;
            if (!DateTime.TryParse(pet.Birthdate.ToString(), out tempBirthdate) || string.IsNullOrEmpty(pet.Birthdate.ToString()))
            {
                throw new InvalidDataException("Invalid Data: The Pet's birthday can NOT be empty");
            }
            pet.Birthdate = tempBirthdate;

            DateTime tempSoldDate = pet.SoldDate;
            if (!DateTime.TryParse(pet.SoldDate.ToString(), out tempSoldDate))
            {
                throw new InvalidDataException($"The Pet's Sold Date has to be in a readable format such as MM/dd/YYYY");
            }

            pet.SoldDate = tempSoldDate;

            if (string.IsNullOrEmpty(pet.Color))
            {
                throw new InvalidDataException($"Invalid Data: Please make sure to enter the color of the pet");
            }

            if (pet.Price < 0)
            {
                throw new InvalidDataException($"The price can not be negative, please enter a valid price");
            }
            /*var NewPet = new Pet
            {
                Name = name,
                Type = type,
                Birthdate = birthday,
                SoldDate = solddate,
                Color = color,
                PreviousOwner = previousowner,
                Price = price
            };*/

            return _petRepo.CreatePet(pet);
        }

        public Pet ReadPetById(int id)
        {
            if (!IdVerifier(id))
            {
                throw new InvalidDataException($"The Id you entered does NOT exist");
            }
            return _petRepo.ReadById(id);
        }

        public Pet ReadPetByIdWithOwner(int id)
        {
            if (!IdVerifier(id))
            {
                throw new InvalidDataException($"The Id you entered does NOT exist");
            }
            return _petRepo.ReadByIdWithOwner(id);
        }

        public Pet DeletePet(int id)
        {
            /*if (!IdVerifier(id))
            {
                throw new InvalidDataException($"The Id you entered does NOT exist");
            }*/
            return _petRepo.DeletePet(id);
        }

        public Pet UpdatePet(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                throw new InvalidDataException("Invalid Data: The Pet's name can NOT be empty");
            }
            if (string.IsNullOrEmpty(pet.Type))
            {
                throw new InvalidDataException("Invalid Data: The Pet's type can NOT be empty");
            }

            DateTime tempBirthdate = pet.Birthdate;
            if (!DateTime.TryParse(pet.Birthdate.ToString(), out tempBirthdate) || string.IsNullOrEmpty(pet.Birthdate.ToString()))
            {
                throw new InvalidDataException("Invalid Data: The Pet's birthday can NOT be empty");
            }
            pet.Birthdate = tempBirthdate;

            DateTime tempSoldDate = pet.SoldDate;
            if (!DateTime.TryParse(pet.SoldDate.ToString(), out tempSoldDate))
            {
                throw new InvalidDataException($"The Pet's Sold Date has to be in a readable format such as MM/dd/YYYY");
            }

            pet.SoldDate = tempSoldDate;

            if (string.IsNullOrEmpty(pet.Color))
            {
                throw new InvalidDataException($"Invalid Data: Please make sure to enter the color of the pet");
            }

            if (pet.Price < 0)
            {
                throw new InvalidDataException($"The price can not be negative, please enter a valid price");
            }

            /*var NewPet = new Pet
            {
                ID = id,
                Name = newName,
                Type = newType,
                Birthdate = newBirthday,
                SoldDate = newSoldDate,
                Color = newColor,
                PreviousOwner = newPreviousOwner,
                Price = newPrice
            };*/

            _petRepo.UpdatePet(pet);

            return pet;
        }

        public List<Pet> SortPetsByPrice()
        {
            List<Pet> SortedByPrice = _petRepo.ReadPets().ToList();
            SortedByPrice.Sort();
            return SortedByPrice;
        }

        public List<Pet> GetFiveCheapestPets()
        {
            List<Pet> tempPetList = new List<Pet>();
            int count = 0;
            foreach (var pet in SortPetsByPrice())
            {
                if (count < 5)
                {
                    tempPetList.Add(pet);
                    count++;
                }
            }

            return tempPetList;

        }

        public bool IdVerifier(int id)
        {
            foreach (var pet in GetPets())
            {
                if (id == pet.ID)
                {
                    return true;
                }
            }

            return false;
        }
    }
}