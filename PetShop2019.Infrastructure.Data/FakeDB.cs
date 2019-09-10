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
        public List<Owner> OwnerList { get; set; }

        public FakeDB()
        {
            OwnerList = InitOwnerData();
            PetList = InitData(OwnerList);
        }

        public static List<Owner> InitOwnerData()
        {
            List<Owner> tempOwners = new List<Owner>();
            var owner1 = new Owner
            {
                id = 1,
                FirstName = "OwnerName_1",
                LastName = "OwnerLastName_1",
                Address = "OwnerAddress_1",
                PhoneNumber = "OwnerPhone_1",
                Email = "OwnerMail_1"
            };
            tempOwners.Add(owner1);

            var owner2 = new Owner
            {
                id = 2,
                FirstName = "OwnerName_2",
                LastName = "OwnerLastName_2",
                Address = "OwnerAddress_2",
                PhoneNumber = "OwnerPhone_2",
                Email = "OwnerMail_2"
            };
            tempOwners.Add(owner2);

            var owner3 = new Owner
            {
                id = 3,
                FirstName = "OwnerName_3",
                LastName = "OwnerLastName_3",
                Address = "OwnerAddress_3",
                PhoneNumber = "OwnerPhone_3",
                Email = "OwnerMail_3"
            };
            tempOwners.Add(owner3);

            var owner4 = new Owner
            {
                id = 4,
                FirstName = "OwnerName_4",
                LastName = "OwnerLastName_4",
                Address = "OwnerAddress_4",
                PhoneNumber = "OwnerPhone_4",
                Email = "OwnerMail_4"
            };
            tempOwners.Add(owner4);

            return tempOwners;
        }

        public static List<Pet> InitData(List<Owner> owners)
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
                PreviousOwner = owners[0],
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
                PreviousOwner = owners[1],
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
                PreviousOwner = owners[2],
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
                PreviousOwner = owners[3],
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
                PreviousOwner = owners[0],
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
                PreviousOwner = owners[1],
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
                PreviousOwner = owners[2],
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
                PreviousOwner = owners[3],
                Price = 800.00
            };
            temp.Add(pet8);

            return temp;
        }
    }
}