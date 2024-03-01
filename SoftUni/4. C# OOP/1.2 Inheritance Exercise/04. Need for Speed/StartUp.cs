using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(100, 30);

            car.Drive(2);

            Console.WriteLine(car.Fuel);

            SportCar sportCar = new SportCar(120, 120);
            sportCar.Drive(10);
            Console.WriteLine(sportCar.Fuel);

        }
    }
}
