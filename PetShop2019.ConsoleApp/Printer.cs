using System;
using PetShop2019.Core.ApplicationService;

namespace PetShop2019.ConsoleApp
{
    public class Printer : IPrinter
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        public void StartUi()
        {
            int menuSelection = 0;
            int exit = 9;
            while (menuSelection != exit)
            {
                menuMain();
                while (!int.TryParse(Console.ReadLine(), out menuSelection) || menuSelection <= 0 || menuSelection > exit)
                {
                    Console.WriteLine("\nPlease enter a number from 1-"+exit+" to select a menu item");
                }

                switch (menuSelection)
                {
                    case 1:
                        //List All Pets Option
                        Console.Clear();
                        
                        PrintPets();

                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;
                    case 2:
                        //Create New Pet Option
                        Console.Clear();

                        CreatePetOption();

                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;
                    case 3:
                        //Read Pet By Id Option
                        Console.Clear();

                        GetPetByIdOption();

                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;
                    case 4:
                        //Update Pet Option
                        Console.Clear();
                        
                        UpdatePetOption();

                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;
                    case 5:
                        //Remove Pet Option
                        Console.Clear();

                        DeletePetByIdOption();
                        
                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;
                    case 6:
                        //Search Pets By Type Option
                        Console.Clear();

                        GetPetByTypeOption();

                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;
                    case 7:
                        //Sort Pets By Price Option
                        Console.Clear();

                        printSortedByPrice();

                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;
                    case 8:
                        //Get 5 Cheapest Available Pets Option
                        Console.Clear();

                        GetFiveCheapestPetsOption();

                        Console.WriteLine("\nPress enter to return to the main menu.");
                        Console.ReadLine();
                        break;

                }
            }

            if (menuSelection == exit)
            {
                Console.WriteLine("Bye.");
            }
        }

        public void menuMain()
        {
            Console.Clear();
            Console.WriteLine("   Pet Shop Menu");
            Console.WriteLine("1: List all available pets");
            Console.WriteLine("2: Create a new pet");
            Console.WriteLine("3: Read Pet By ID");
            Console.WriteLine("4: Update Pet Information");
            Console.WriteLine("5: Delete a Pet");
            Console.WriteLine("6: Search Pet By Type");
            Console.WriteLine("7: Sort List of Pets by price");
            Console.WriteLine("8: Get a list of the 5 cheapest pets available");
            Console.WriteLine("9: Exit");
        }

        public void PrintPets()
        {
            Console.WriteLine("List of available pets: \n");
            foreach (var pet in _petService.GetPets())
            {
                Console.WriteLine(pet.ToString());
            }
        }

        public void CreatePetOption()
        {
            Console.WriteLine($"Here you can create a new pet!\nPlease start by entering the pet's name:");
            var petName = Console.ReadLine();
            Console.WriteLine($"Now please enter the Type of pet you wish to create:");
            var petType = Console.ReadLine();
            Console.WriteLine($"Next please enter the Color of the pet");
            var petColor = Console.ReadLine();
            Console.WriteLine($"Now please enter the pet's date of birth in the MM/dd/YYYY format");
            DateTime petBirthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out petBirthDate))
            {
                Console.WriteLine($"Please enter a valid date");
            }
            Console.WriteLine($"Now please enter the pet's date of sale in the MM/dd/YYYY format");
            DateTime petSoldDate;
            while (!DateTime.TryParse(Console.ReadLine(), out petSoldDate))
            {
                Console.WriteLine($"Please enter a valid date");
            }
            Console.WriteLine($"Please enter the name of the pet's previous owner");
            var petPreOwner = Console.ReadLine();
            Console.WriteLine($"Finally please enter the price of the pet");
            double petPrice;
            while (!double.TryParse(Console.ReadLine(), out petPrice))
            {
                Console.WriteLine($"Please enter a valid price (Example 150.00)");
            }
            //_petService.CreatePet(petName, petType, petBirthDate, petSoldDate, petColor, petPreOwner, petPrice);

            Console.WriteLine($"Pet Creation Completed.");

        }

        public void GetPetByIdOption()
        {
            Console.WriteLine($"Here you can find any pet by inputting it's ID\nPlease enter the ID of the pet you wish to gain information about:");
            int petID;
            while (!int.TryParse(Console.ReadLine(), out petID) || _petService.IdVerifier(petID)==false)
            {
                Console.WriteLine($"Please enter a number between 1 and {_petService.GetPets().Count}");
            }

            Console.WriteLine(_petService.ReadPetById(petID).ToString());

        }

        public void GetPetByTypeOption()
        {
            Console.WriteLine($"Here you can search for pets by their type!\nPlease enter the Type of pet of wish to browse");
            var petType = Console.ReadLine();
            Console.WriteLine($"Here is a list of all our available {petType}s!");
            foreach (var pet in _petService.GetPetsByType(petType))
            {
                Console.WriteLine(pet.ToString());
            }
        }

        public void DeletePetByIdOption()
        {
            Console.WriteLine($"Here you can delete a pet by entering it's ID!\nPlease enter the ID of the pet which you wish to delete from the database");
            int petID;
            while (!int.TryParse(Console.ReadLine(), out petID) || !_petService.IdVerifier(petID))
            {
                Console.WriteLine($"Please enter a valid id (1-{_petService.GetPets().Count})");
            }

            Console.WriteLine($"The follow pet has been deleted from the database\n{_petService.DeletePet(petID).ToString()}");
        }

        public void UpdatePetOption()
        {
            Console.WriteLine($"Here you can update a pet by entering the ID of the pet you wish to update\nPlease enter the ID of the pet to update below:");
            int petID;
            while (!int.TryParse(Console.ReadLine(), out petID) || !_petService.IdVerifier(petID))
            {
                Console.WriteLine($"Please enter a valid id (1-{_petService.GetPets().Count})");
            }
            Console.WriteLine($"Please enter the new name of the pet");
            var petName = Console.ReadLine();
            Console.WriteLine($"Now please enter the Type of the pet");
            var petType = Console.ReadLine();
            Console.WriteLine($"Next please enter the Color of the pet");
            var petColor = Console.ReadLine();
            Console.WriteLine($"Now please enter the pet's date of birth in the MM/dd/YYYY format");
            DateTime petBirthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out petBirthDate))
            {
                Console.WriteLine($"Please enter a valid date");
            }
            Console.WriteLine($"Now please enter the pet's date of sale in the MM/dd/YYYY format");
            DateTime petSoldDate;
            while (!DateTime.TryParse(Console.ReadLine(), out petSoldDate))
            {
                Console.WriteLine($"Please enter a valid date");
            }
            Console.WriteLine($"Please enter the name of the pet's previous owner");
            var petPreOwner = Console.ReadLine();
            Console.WriteLine($"Finally please enter the price of the pet");
            double petPrice;
            while (!double.TryParse(Console.ReadLine(), out petPrice))
            {
                Console.WriteLine($"Please enter a valid price (Example 150.00)");
            }

            //_petService.UpdatePet(petID, petName, petType, petBirthDate, petSoldDate, petColor, petPreOwner, petPrice);

            Console.WriteLine($"The pet information has been updated");

        }

        public void printSortedByPrice()
        {
            Console.WriteLine($"List of all available pets sorted by price:");
            foreach (var pet in _petService.SortPetsByPrice())
            {
                Console.WriteLine($"Price: {pet.Price} \t {pet.ToString()}");
            }
        }

        public void GetFiveCheapestPetsOption()
        {
            Console.WriteLine($"Here is a list of the 5 cheapest available pets:\n");
            foreach (var pet in _petService.GetFiveCheapestPets())
            {
                Console.WriteLine(pet.ToString());
            }
        }
    }
}