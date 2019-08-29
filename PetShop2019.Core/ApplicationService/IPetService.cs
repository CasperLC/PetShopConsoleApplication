﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.ApplicationService
{
    public interface IPetService
    {
        //Gets and returns a list of all pets
        List<Pet> GetPets();

        //Gets and returns a list of pets of the given type
        List<Pet> GetPetsByType(string type);

        //Creates a new pet
        Pet CreatePet(string name,
            string type,
            DateTime birthday,
            DateTime solddate,
            string color,
            string previousowner,
            double price);

        //Deletes the pet with the given id
        void DeletePet(int id);

        //Updates a pet with the given id
        Pet UpdatePet(int id,
            string newName,
            string newType,
            DateTime newBirthday,
            DateTime newSoldDate,
            string newColor,
            string newPreviousOwner,
            double newPrice);

        //returns a list of pets sorted by price(descending)
        List<Pet> SortPetsByPrice();

        //returns a list of the 5 cheapest pets available
        List<Pet> GetFiveCheapestPets();
    }
}