using System;
using PetShop2019.Core.ApplicationService;
using PetShop2019.Core.ApplicationService.Implementation;

namespace PetShop2019.ConsoleApp
{
    public class Printer
    {
        private IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;

            PrintPets();

        }

        public void PrintPets()
        {
            foreach (var pet in _petService.GetPets())
            {
                Console.WriteLine("Type: " + pet.Type + " Name: " + pet.Name);
            }
        }
    }