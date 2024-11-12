using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoservice.Models;
using Autoservice.Controllers;

namespace Autoservice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int defaultVehiclesCount = 5;
            int defaultCountPartEch = 5; 

            СarserviceController сarserviceController = new СarserviceController(defaultVehiclesCount, defaultCountPartEch);

            Console.WriteLine("Добро пожаловать в игру \"Автосерис\"! \n" +
                "Ваша задача ремонтировать автомобили, за что вы будете получать денежное вознаграждение.\n");

            сarserviceController.ShowQueue();

            Console.WriteLine("\nНажмите любую клавишу, чтобы начать ремонтировать автомобили.");

            Console.ReadKey();

            сarserviceController.RunRepair();
            сarserviceController.PrintResults();
        }
    }
}