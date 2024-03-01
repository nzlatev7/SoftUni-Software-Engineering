using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        private int capacity;
        private List<Car> cars;
        public int Count { get { return cars.Count; } }

        public string AddCar(Car car)
        {
            //unique ???
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            Car carForRemove = cars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault();

            if (carForRemove == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(carForRemove);
            return $"Successfully removed {registrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            return cars.Find(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currentNumber in registrationNumbers)
            {
                RemoveCar(currentNumber);
            }
        }
    }
}
