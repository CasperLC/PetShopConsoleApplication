using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PetShop2019.Core.Entities;

namespace PetShop.Infrastructure.SQL
{
    public class DbInitializer: IDbInitializer
    {
        public void Initialize(PetShop2019Context context)
        {
            context.Database.EnsureCreated();

            /*if (context.Pets.Any() || context.Owners.Any())
            {
                context.Database.ExecuteSqlCommand("DROP TABLE Pets");
                context.Database.ExecuteSqlCommand("DROP TABLE Owners");
                context.Database.EnsureCreated();
            }*/


            if (EnumerableExtensions.Any(context.Pets))
            {
                return;
            }


            var owner1 = context.Owners.Add(new Owner()
            {
                Address = "OwnerAddress1",
                Email = "OwnerEmail1",
                FirstName = "Owner1",
                LastName = "Last1",
                PhoneNumber = "Phone1"
            }).Entity;

            var owner2 = context.Owners.Add(new Owner()
            {
                Address = "OwnerAddress2",
                Email = "OwnerEmail2",
                FirstName = "Owner2",
                LastName = "Last2",
                PhoneNumber = "Phone2"
            }).Entity;

            var pet1 = context.Pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("15/09/2019"),
                SoldDate = DateTime.Parse("20/09/2019"),
                Name = "Pet1",
                Color = "Black",
                Price = 200.00,
                Type = "Cat",
                PetOwners = new List<PetOwner>{new PetOwner()
                {
                    Owner = owner1,
                    OwnerId = owner1.id
                }, new PetOwner()
                {
                    Owner = owner2,
                    OwnerId = owner2.id
                }}
            }).Entity;

            var pet2 = context.Pets.Add(new Pet()
            {
                Birthdate = DateTime.Parse("16/09/2019"),
                SoldDate = DateTime.Parse("21/09/2019"),
                Name = "Pet2",
                Color = "White",
                Price = 200.00,
                Type = "Dog",
                PetOwners = new List<PetOwner>{new PetOwner()
                {
                    Owner = owner2,
                    OwnerId = owner2.id
                }}
            }).Entity;
            
            context.SaveChanges();
        }
    }
}