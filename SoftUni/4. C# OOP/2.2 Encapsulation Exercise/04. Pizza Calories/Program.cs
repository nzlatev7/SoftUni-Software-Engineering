using System;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string pizzaName = string.Empty;

                if (pizzaInfo.Length != 1)
                {
                    pizzaName = pizzaInfo.Skip(1).First();
                }

                string[] info = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = info[1];
                string technique = info[2];
                decimal grams = decimal.Parse(info[3]);

                Dough dough = new Dough(type, technique, grams);

                Pizza pizza = new Pizza(pizzaName, dough);

                string commnad;
                while ((commnad = Console.ReadLine()) != "END")
                {
                    string[] data = commnad
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string type1 = data[1];
                    decimal grams1 = decimal.Parse(data[2]);

                    Topping topping = new Topping(type1, grams1);
                    pizza.AddToppings(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
