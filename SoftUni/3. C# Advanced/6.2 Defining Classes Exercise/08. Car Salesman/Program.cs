using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //validate the model ???  - maybe
                string model = data[0];
                int power = int.Parse(data[1]);

                Engine engine;

                if (data.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int displacement))
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = data[2];

                        engine = new Engine(model, power, efficiency);
                    }
                }
                else
                {
                    int displacement = int.Parse(data[2]);
                    string efficiency = data[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //"{model} {engine} {weight} {color}".

                string model = data[0];
                string engineModel = data[1];

                Engine engine = engines.Find(x => x.Model == engineModel);

                Car car;

                if (data.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int weight))
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = data[2];
                        car = new Car(model, engine, color);
                    }
                }
                else
                {
                    int weight = int.Parse(data[2]);
                    string color = data[3];

                    car = new Car(model, engine, weight, color);
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.Write(car);
            }
        }

    }
}
