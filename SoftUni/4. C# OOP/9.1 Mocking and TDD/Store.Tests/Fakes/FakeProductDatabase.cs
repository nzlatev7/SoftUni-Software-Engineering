using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad;
using zad.Contracts;

namespace Store.Tests.Fakes
{
    public class FakeProductDatabase : IProductDatabase
    {
        public int SaveMethodCalls = 0;

        public int Count { get; private set; }

        public Product RemovedProduct { get; set; }
        public Product AddedProduct { get; set; }

        public void Add(Product product)
        {
            Count++;

            AddedProduct = product;
        }

        public void Remove(Product product)
        {
            List<Product> products = new List<Product>()
            {
                new Product(1, "1", 1, 1),
                new Product(2, "2", 2, 2),
            };

            products.Remove(product);

            Count--;

            RemovedProduct = product;
        }

        public bool Contains(Product product)
        {
            return false;
        }
        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product(1, "1", 1, 1),
                new Product(2, "2", 2, 2),
            };
        }
        
        public void Save()
        {
            SaveMethodCalls++;
        }
    }
}
