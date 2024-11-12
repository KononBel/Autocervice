using Autoservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Controllers
{
    class СarserviceController
    {
        private Сarservice _carservice;

        public СarserviceController(int vehiclesCount, int countPartEch)
        {
            Storage partsStorage = new Storage(countPartEch);
            Queue<Vehicle> vehicles = VehicleFactory.CreateQueue(countPartEch);

            _carservice = new Сarservice(partsStorage, vehicles);
        }

        public void RunRepair()
        {
            const string commandGoRepair = "1";
            const string commandCompleteRepair = "2";
            const string commandBreakRepair = "3";
            const string commandBlowUp = "4";

            while (_carservice.Vehicles.Count > 0)
            {
                _carservice.LiftVehicle();

                bool isWork = true;

                while (isWork)
                {
                    Console.Clear();

                    Console.WriteLine($"Касса: {_carservice.Money}$");
                    Console.WriteLine($"\nНеобходимо починить {_carservice.CurrentVehicle.Name}. Выберите действие:\n");

                    string choice;

                    Console.WriteLine($"{commandGoRepair}. Приступить к ремонту");
                    Console.WriteLine($"{commandCompleteRepair}. Завершить ремонт");
                    Console.WriteLine($"{commandBreakRepair}. Отказаться от ремонта");
                    Console.WriteLine($"{commandBlowUp}. Взорвать автосервис");
                    Console.Write("\nСделайте ваш выбор: ");

                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case commandGoRepair:
                            _carservice.Repair();
                            break;

                        case commandCompleteRepair:
                            _carservice.CompleteRepair(ref isWork);
                            break;

                        case commandBreakRepair:
                            _carservice.BreakRepair(ref isWork);
                            break;

                        case commandBlowUp:
                            _carservice.BurnOut(ref isWork);
                            break;

                        default:
                            Console.WriteLine("Такого варианта нет! Повторите попытку!");
                            break;
                    }

                    Console.ReadKey();
                }
            }
        }

        public void ShowQueue()
        {
            Console.WriteLine("В данный момент в очереди на ремонт находятся:\n");

            _carservice.Vehicles.ForEach(vehicle => Console.WriteLine($"{vehicle.Name}"));
        }

        public void PrintResults()
        {
            Console.Clear();

            Console.WriteLine($"Игра закончена! Касса составила: {_carservice.Money}$");

            if (_carservice.Money > 0)
                Console.WriteLine("Вы молодец, продолжайте в том же духе!");
            else
                Console.WriteLine("Вы никчёмный предприниматель, идите учитесь, а не играйте в игрушки! Бездарь.");
        }
    }
}