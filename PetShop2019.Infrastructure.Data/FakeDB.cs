using System;
using System.Collections;
using System.Collections.Generic;
using PetShop2019.Core.Entities;

namespace PetShop2019.Infrastructure.Data
{
    public class FakeDB
    {
        public static IEnumerable<Pet> Pets;
        public List<Pet> PetList { get; set; }

        public FakeDB()
        {
            PetList = InitData();
        }

        public static List<Pet> InitData()
        {
            List<Pet> temp = new List<Pet>();
            var pet1 = new Pet
            {
                ID = 1,
                Name = "PetName_1",
                Type = "Dog",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Green",
                PreviousOwner = "Pre-Owner_1",
                Price = 200.00
            };
            temp.Add(pet1);

            var pet2 = new Pet
            {
                ID = 2,
                Name = "PetName_2",
                Type = "Cat",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Blue",
                PreviousOwner = "Pre-Owner_2",
                Price = 250.00
            };
            temp.Add(pet2);

            var pet3 = new Pet
            {
                ID = 3,
                Name = "PetName_3",
                Type = "Dog",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Black",
                PreviousOwner = "Pre-Owner_3",
                Price = 350.00
            };
            temp.Add(pet3);

            var pet4 = new Pet
            {
                ID = 4,
                Name = "PetName_4",
                Type = "Cat",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Orange",
                PreviousOwner = "Pre-Owner_4",
                Price = 150.00
            };
            temp.Add(pet4);

            return temp;
        }
    }
}