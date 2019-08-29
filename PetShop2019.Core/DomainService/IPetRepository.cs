using System.Collections;
using System.Collections.Generic;
using PetShop2019.Core.Entities;

namespace PetShop2019.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
    }
}