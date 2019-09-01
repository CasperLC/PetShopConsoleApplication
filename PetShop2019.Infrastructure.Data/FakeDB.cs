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
                Price = 100.00
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
                Price = 200.00
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
                Price = 300.00
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
                Price = 400.00
            };
            temp.Add(pet4);

            var pet5 = new Pet
            {
                ID = 5,
                Name = "PetName_5",
                Type = "Dog",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Green",
                PreviousOwner = "Pre-Owner_5",
                Price = 500.00
            };
            temp.Add(pet5);

            var pet6 = new Pet
            {
                ID = 6,
                Name = "PetName_6",
                Type = "Cat",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Blue",
                PreviousOwner = "Pre-Owner_6",
                Price = 600.00
            };
            temp.Add(pet6);

            var pet7 = new Pet
            {
                ID = 7,
                Name = "PetName_7",
                Type = "Dog",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Black",
                PreviousOwner = "Pre-Owner_7",
                Price = 777.77
            };
            temp.Add(pet7);

            var pet8 = new Pet
            {
                ID = 8,
                Name = "PetName_8",
                Type = "Cat",
                Birthdate = DateTime.Today,
                SoldDate = DateTime.Now,
                Color = "Orange",
                PreviousOwner = "Pre-Owner_8",
                Price = 800.00
            };
            temp.Add(pet8);

            return temp;
        }
    }
}