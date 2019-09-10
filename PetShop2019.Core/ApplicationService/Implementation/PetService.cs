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

        public Pet CreatePet(string name, string type, DateTime birthday, DateTime solddate, string color, Owner previousowner,
            double price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidDataException("Invalid Data: The Pet's name can NOT be empty");
            }
            if (string.IsNullOrEmpty(type))
            {
                throw new InvalidDataException("Invalid Data: The Pet's type can NOT be empty");
            }

            if (!DateTime.TryParse(birthday.ToString(), out birthday) || string.IsNullOrEmpty(birthday.ToString()))
            {
                throw new InvalidDataException("Invalid Data: The Pet's birthday can NOT be empty");
            }
            if (!DateTime.TryParse(solddate.ToString(), out solddate))
            {
                throw new InvalidDataException($"The Pet's Sold Date has to be in a readable format such as MM/dd/YYYY");
            }

            if (string.IsNullOrEmpty(color))
            {
                throw new InvalidDataException($"Invalid Data: Please make sure to enter the color of the pet");
            }

            if (price < 0)
            {
                throw new InvalidDataException($"The price can not be negative, please enter a valid price");
            }
            var NewPet = new Pet
            {
                Name = name,
                Type = type,
                Birthdate = birthday,
                SoldDate = solddate,
                Color = color,
                PreviousOwner = previousowner,
                Price = price
            };

            return _petRepo.CreatePet(NewPet);
        }

        public Pet ReadPetById(int id)
        {
            if (!IdVerifier(id))
            {
                throw new InvalidDataException($"The Id you entered does NOT exist");
            }
            return _petRepo.ReadById(id);
        }

        public Pet DeletePet(int id)
        {
            if (!IdVerifier(id))
            {
                throw new InvalidDataException($"The Id you entered does NOT exist");
            }
            return _petRepo.DeletePet(id);
        }

        public Pet UpdatePet(int id, string newName, string newType, DateTime newBirthday, DateTime newSoldDate, string newColor,
            Owner newPreviousOwner, double newPrice)
        {
            if (string.IsNullOrEmpty(newName))
            {
                throw new InvalidDataException("Invalid Data: The Pet's name can NOT be empty");
            }
            if (string.IsNullOrEmpty(newType))
            {
                throw new InvalidDataException("Invalid Data: The Pet's type can NOT be empty");
            }

            if (!DateTime.TryParse(newBirthday.ToString(), out newBirthday) || string.IsNullOrEmpty(newBirthday.ToString()))
            {
                throw new InvalidDataException("Invalid Data: The Pet's birthday can NOT be empty");
            }
            if (!DateTime.TryParse(newSoldDate.ToString(), out newSoldDate))
            {
                throw new InvalidDataException($"The Pet's Sold Date has to be in a readable format such as MM/dd/YYYY");
            }

            if (string.IsNullOrEmpty(newColor))
            {
                throw new InvalidDataException($"Invalid Data: Please make sure to enter the color of the pet");
            }

            if (newPrice < 0)
            {
                throw new InvalidDataException($"The price can not be negative, please enter a valid price");
            }

            var NewPet = new Pet
            {
                ID = id,
                Name = newName,
                Type = newType,
                Birthdate = newBirthday,
                SoldDate = newSoldDate,
                Color = newColor,
                PreviousOwner = newPreviousOwner,
                Price = newPrice
            };

            _petRepo.UpdatePet(NewPet);

            return NewPet;
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