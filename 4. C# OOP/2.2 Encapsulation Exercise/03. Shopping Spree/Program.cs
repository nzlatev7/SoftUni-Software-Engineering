using System;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] allDataPeople = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var person in allDataPeople)
                {
                    string[] personInfo = person.Split("=");

                    people.Add(new Person(personInfo[0], decimal.Parse(personInfo[1])));
                }

                string[] allDataProducts = Console.ReadLine()
                        .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var current in allDataProducts)
                {
                    string[] personInfo = current.Split("=");

                    products.Add(new Product(personInfo[0], decimal.Parse(personInfo[1])));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] info = command.Split();

                string personName = info[0];
                string productName = info[1];

                var product = products.Find(x => x.Name == productName);
                var person = people.Find(x => x.Name == personName);

                if (product != null && person != null)
                {
                    string message = person.AddProduct(product);
                    Console.WriteLine(message);
                }         
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
