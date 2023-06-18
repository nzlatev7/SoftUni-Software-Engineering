using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            var vehicle = Vehicles.Find(x => x.VIN == vin);

            if (vehicle == null)
            {
                return false;
            }

            Vehicles.Remove(vehicle);

            return true;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            return Vehicles
                .OrderBy(x => x.Mileage)
                .First();
        }

        public string Report()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine("Vehicles in the preparatory:");

            foreach (var vehicle in Vehicles)
            {
                info.AppendLine(vehicle.ToString());
            }

            return info.ToString().TrimEnd();
        }

    }
}
