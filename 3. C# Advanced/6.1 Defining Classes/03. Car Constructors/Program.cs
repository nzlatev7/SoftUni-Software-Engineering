using CarManufacturer;
using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car firstCar = new Car();
            Car secondCar = new Car("12","12", 1999);
            Car thirdCar = new Car("12", "12", 1999, 20,5);
        }
    }
}
