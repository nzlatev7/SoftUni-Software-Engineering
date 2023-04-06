using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, decimal>();

            List<Product> products = new List<Product>();
            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] data = command.Split();
                string name = data[0];
                decimal price = decimal.Parse(data[1]);
                int quantity = int.Parse(data[2]);

                if (products.Any(x => x.Name == name))
                {
                    var productForUpdate = products.Find(x => x.Name == name);
                    productForUpdate.Price = price;
                    productForUpdate.Quantity += quantity;
                    continue;
                }

                Product product = new Product(name, price, quantity);
                products.Add(product);
            }
            foreach (var product in products)
            {
                dictionary.Add(product.Name, product.Price * product.Quantity);
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
    public class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}