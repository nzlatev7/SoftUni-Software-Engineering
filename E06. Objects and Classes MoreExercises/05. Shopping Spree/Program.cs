using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //for Persons
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            for (int i = 0; i < 1; i++)
            {
                string input = Console.ReadLine();
                string[] peoples = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var people in peoples)
                {
                    string[] personInfo = people.Split("=");
                    string name = personInfo[0];
                    double money = double.Parse(personInfo[1]);
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
            }
            //for Products
            for (int i = 0; i < 1; i++)
            {
                string input = Console.ReadLine();
                string[] productss = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var productt in productss)
                {
                    string[] productInfo = productt.Split("=");
                    string name = productInfo[0];
                    double cost = double.Parse(productInfo[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
            }

            //while end
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] info = command.Split();
                string name = info[0];
                string product = info[1];

                var personForBuying = persons.Find(x => x.Name == name);
                var productForBuying = products.Find(x => x.Name == product);

                if (personForBuying.Money >= productForBuying.Cost)
                {
                    personForBuying.Products.Add(productForBuying);
                    personForBuying.Money -= productForBuying.Cost;
                    Console.WriteLine($"{personForBuying.Name} bought {productForBuying.Name}");
                }
                else
                {
                    Console.WriteLine($"{personForBuying.Name} can't afford {productForBuying.Name}");
                }
            }
            foreach (Person person in persons)
            {
                if (person.Products.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
    public class Person
    {
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }
        public string Name { get; set; }
        public double Money { get; set; }

        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}

