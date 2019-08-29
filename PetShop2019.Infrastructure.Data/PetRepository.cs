using System.Collections.Generic;
using PetShop2019.Core.DomainService;
using PetShop2019.Core.Entities;

namespace PetShop2019.Infrastructure.Data
{
    public class PetRepository: IPetRepository
    {
        private FakeDB fakeDB;

        public PetRepository()
        {
            this.fakeDB = new FakeDB();
        }
        public IEnumerable<Pet> ReadPets()
        {
            return 
        }
    }
}