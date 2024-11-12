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
            while (_carservice.Vehicles.Count > 0)
            {
                _carservice.LiftVehicle();

                bool isWork = true;

                while (isWork)
                {
                    Console.Clear();

                    Console.WriteLine($"Касса: {_carservice.Money}$");
                    Console.WriteLine($"\nНеобходимо починить {_carservice.CurrentVehicle.Name}. Выберите действие:\n");

                    const string GoRepair = "1";
                    const string CompleteRepair = "2";
                    const string BreakRepair = "3";
                    const string BlowUp = "4";

                    string choice;

                    Console.WriteLine($"{GoRepair}. Приступить к ремонту");
                    Console.WriteLine($"{CompleteRepair}. Завершить ремонт");
                    Console.WriteLine($"{BreakRepair}. Отказаться от ремонта");
                    Console.WriteLine($"{BlowUp}. Взорвать автосервис");
                    Console.Write("\nСделайте ваш выбор: ");

                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case GoRepair:
                            _carservice.Repair();
                            break;

                        case CompleteRepair:
                            _carservice.CompleteRepair(ref isWork);
                            break;

                        case BreakRepair:
                            _carservice.BreakRepair(ref isWork);
                            break;

                        case BlowUp:
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