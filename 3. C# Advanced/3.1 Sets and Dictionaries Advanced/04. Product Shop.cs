using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, List<Product>>();

            string command;
            while ((command = Console.ReadLine()) != "Revision")
            {
                // input -> "{shop}, {product}, {price}"
                string[] data = command.Split(", ");
                string shop = data[0];
                string productName = data[1];
                decimal price = decimal.Parse(data[2]);

                if (shops.ContainsKey(shop))
                {
                    Product product1 = new Product(productName, price);
                    shops[shop].Add(product1);
                    continue;
                }

                Product product = new Product(productName, price);
                List<Product> products = new List<Product>();
                products.Add(product);

                shops.Add(shop, products);
            }

            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine(shop.Key + "->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.ProductName}, Price: {Math.Round(product.Price, 1 )}");
                }
            }
        }
    }
    class Product
    {
        public Product(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
