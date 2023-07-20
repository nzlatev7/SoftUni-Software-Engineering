using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad.Contracts;

namespace zad
{
    public class ProductTextDatabase : IProductDatabase
    {
        private const string DbPath = @"C:\Users\PC\Documents\c# uroci\softuni\SoftUni\SoftUni-CSharpFundamentals-Jan2023\4. C# OOP\9.1 Mocking and TDD\zad\zad\MyDb.txt";

        private List<Product> products;

        public ProductTextDatabase()
        {
            Load();
        }

        public int Count 
        { 
            get => products.Count; 
            set => Count = value;
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(DbPath))
            {
                writer.WriteLine(JsonConvert.SerializeObject(products));
            }
        }

        public void Load()
        {
            if (!File.Exists(DbPath))
            {
                products = new List<Product>();
            }
            else
            {
                using (StreamReader reader = new StreamReader(DbPath))
                {
                    string jsonContent = reader.ReadToEnd();
                    products = JsonConvert.DeserializeObject<List<Product>>(jsonContent);
                }
            }        
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Remove(Product product)
        {
            products.Remove(product);
        }

        public bool Contains(Product product)
        {
            if (!products.Any(x => x.Id == product.Id))
            {
                return false;
            }

            return true;
        }

        public List<Product> GetAll()
        {
            return products;
        }
    }
}
