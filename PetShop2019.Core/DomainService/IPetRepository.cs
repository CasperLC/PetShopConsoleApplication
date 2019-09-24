using System.Collections;
using System.Collections.Generic;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        Pet ReadById(int id);

        Pet ReadByIdWithOwner(int id);

        Pet CreatePet(Pet pet);

        Pet UpdatePet(Pet petUpdate);

        Pet DeletePet(int id);
/*
        IEnumerable<Pet> PetsByType(string type);

        IEnumerable<Pet> PetsSortedByPrice();

        IEnumerable<Pet> GetFiveCheapestPets();*/

    }
}