using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Models
{
    class Сarservice
    {
        private Storage _storage;

        private Queue<Vehicle> _vehicles;

        private int _money;
        private int _repairCost;
        private int _forfeitUnrepairedBet;
        private int _forfeitRefusalRepair;

        public Сarservice(Storage partsStorage, Queue<Vehicle> vehiclesQueue)
        {
            _storage = partsStorage;
            _vehicles = vehiclesQueue;

            _money = 0;
            _repairCost = 100;
            _forfeitUnrepairedBet = 2;
            _forfeitRefusalRepair = 250;
        }

        public Vehicle CurrentVehicle { get; private set; }

        public List<Vehicle> Vehicles => new List<Vehicle>(_vehicles);

        public int Money => _money;

        public void AcceptVehicle(Vehicle vehicle)
        {
            if (vehicle != null && _vehicles.Count > 0)
                _vehicles.Enqueue(vehicle);
        }

        public void LiftVehicle()
        {
            CurrentVehicle = _vehicles.Dequeue();
        }

        public void Repair()
        {
            InspectVehicle();

            int partNumber = ConsoleReader.ReadInt("\nВведите номер детали, которую хотите заменить: ");
            
            if (partNumber > 0 && partNumber <= CurrentVehicle.Parts.Count)
            {
                Part part = CurrentVehicle.Parts[partNumber - 1];

                if (part != null)
                {
                    Part newPart = _storage.GetAvailablePart(part.Name);

                    if (newPart != null)
                    {
                        if (part.IsBroken)
                            _money += newPart.Cost + _repairCost;

                        CurrentVehicle.ReplacePart(part, newPart);
                        _storage.Remove(newPart);

                        Console.WriteLine($"Деталь {part.Name} заменена в {CurrentVehicle.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"Заменить {part.Name} не получится, эта деталь отсутсвует на складе.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Такой детали в {CurrentVehicle.Name} не обнаружено.");
            }
        }

        public void CompleteRepair(ref bool isWork)
        {
            int forfeit = 0;

            foreach (Part part in CurrentVehicle.Parts)
            {
                if (part.IsBroken)
                    forfeit += part.Cost / _forfeitUnrepairedBet;
            }

            _money -= forfeit;

            Console.WriteLine($"\nВы завершили ремонт {CurrentVehicle.Name}.\n" +
                $"Штраф за неотремонтированные детали составил: {forfeit}$");

            isWork = false;
        }

        public void BreakRepair(ref bool isWork)
        {
            _money -= _forfeitRefusalRepair;

            Console.WriteLine($"\nВы отказались от ремонта {CurrentVehicle.Name}.\n" +
                $"Штраф за отказ от ремонта составил: {_forfeitRefusalRepair}$");

            isWork = false;
        }

        public void BurnOut(ref bool isWork)
        {
            _vehicles.Clear();

            _money = 0;
            isWork = false;

            Console.WriteLine("Автосервис разлетелся на кусочки! От бабок ничего не осталось :(");
        }

        private void InspectVehicle()
        {
            Console.WriteLine($"\nТехническое состояние {CurrentVehicle.Name}: \n");

            int partNumber = 1;

            foreach (Part part in CurrentVehicle.Parts)
            {
                string brokenStatusName = (part.IsBroken) ? "Сломана" : "Целая";

                Console.WriteLine($"{partNumber++}. {part.Name}: {brokenStatusName}");
            }
        }
    }
}