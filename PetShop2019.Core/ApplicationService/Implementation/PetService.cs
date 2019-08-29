using System;
using System.Collections.Generic;
using System.Linq;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.ApplicationService.Implementation
{
    public class PetService: IPetService
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
            throw new NotImplementedException();
        }

        public Pet CreatePet(string name, string type, DateTime birthday, DateTime solddate, string color, string previousowner,
            double price)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public Pet UpdatePet(int id, string newName, string newType, DateTime newBirthday, DateTime newSoldDate, string newColor,
            string newPreviousOwner, double newPrice)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SortPetsByPrice()
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetFiveCheapestPets()
        {
            throw new NotImplementedException();
        }
    }
}