using System;
using System.Collections.Generic;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop2019.Infrastructure.Data
{
    public class PetRepository: IPetRepository
    {
        private FakeDB fakeDB;
        private int id;

        public PetRepository()
        {
            this.fakeDB = new FakeDB();
            this.id = fakeDB.PetList.Count + 1;
        }
        public IEnumerable<Pet> ReadPets()
        {
            return fakeDB.PetList;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in fakeDB.PetList)
            {
                if (pet.ID.Equals(id))
                {
                    return pet;
                }
            }

            return null;

        }

        public Pet CreatePet(Pet pet)
        {
            pet.ID=id;
            fakeDB.PetList.Add(pet);
            id++;
            return pet;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var currentPet = ReadById(petUpdate.ID);
            if (currentPet != null)
            {
                currentPet.Name = petUpdate.Name;
                currentPet.Type = petUpdate.Type;
                currentPet.Birthdate = petUpdate.Birthdate;
                currentPet.SoldDate = petUpdate.SoldDate;
                currentPet.Color = petUpdate.Color;
                currentPet.PreviousOwner = petUpdate.PreviousOwner;
                currentPet.Price = petUpdate.Price;
                return currentPet;
            }

            return null;
        }

        public Pet DeletePet(int id)
        {
            Pet temPet = null;
            foreach (var pet in fakeDB.PetList)
            {
                if (pet.ID == id)
                {
                    temPet = pet;
                }
            }

            fakeDB.PetList.Remove(temPet);
            return temPet;
        }

    }
}