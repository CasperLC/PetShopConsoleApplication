﻿using System.Collections.Generic;

namespace PetShop2019.Core.Entities
{
    public class Owner
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<PetOwner> PetOwners { get; set; }
        //public List<Pet> PetsOwnedList { get; set; }

    }
}