using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop2019.Core.ApplicationService;
using PetShop2019.Core.ApplicationService.Implementation;
using PetShop2019.Core.DomainService;
using PetShop2019.Infrastructure.Data;

namespace PetShop2019.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.StartUi();
        }
    }
}
