using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Models
{
    static class VehicleFactory
    {
        private static Random s_random;

        private static string[] s_vehiclesNames;

        static VehicleFactory()
        {
            s_random = new Random(Guid.NewGuid().GetHashCode());

            s_vehiclesNames = new string[] { "Audi", "Ford", "Porsche", "Lada", "BMW",
                "Jeep", "Hummer", "Cadillac", "Lincoln", "Toyota" };
        }

        public static Queue<Vehicle> CreateQueue(int vehiclesCount)
        {
            Queue<Vehicle> vehicles = new Queue<Vehicle>();

            for (int i = 0; i < vehiclesCount; i++)
            {
                Vehicle newVehicle = new Vehicle(GetVehicleName(), Parts.Get());

                newVehicle.BreakDown();
                vehicles.Enqueue(newVehicle);
            }

            return vehicles;
        }

        private static string GetVehicleName()
        {
            int vehicleNameIndex = s_random.Next(0, s_vehiclesNames.Length);

            return s_vehiclesNames[vehicleNameIndex];
        }
    }
}