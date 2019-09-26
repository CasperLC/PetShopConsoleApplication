using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.ApplicationService
{
    public interface IPetService
    {
        //Gets and returns a list of all pets
        List<Pet> GetPets();

        //Gets pets using the filter entity
        List<Pet> GetFilteredPets(Filter filter);

        //Gets and returns a list of pets of the given type
        List<Pet> GetPetsByType(string type);

        //Creates a new pet
        Pet CreatePet(Pet pet);

        //Gets the pet with the given id
        Pet ReadPetById(int id);

        //Gets the pet with the given id and their owner
        Pet ReadPetByIdWithOwner(int id);

        //Deletes the pet with the given id
        Pet DeletePet(int id);

        //Updates a pet with the given id
        Pet UpdatePet(Pet updatedPet);

        //returns a list of pets sorted by price(descending)
        List<Pet> SortPetsByPrice();

        //returns a list of the 5 cheapest pets available
        List<Pet> GetFiveCheapestPets();

        //Verifies the id, returns true if the ID exits and false otherwise.
        bool IdVerifier(int id);
    }
}