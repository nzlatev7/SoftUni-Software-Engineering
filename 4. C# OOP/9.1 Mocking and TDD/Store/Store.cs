using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad.Contracts;

namespace zad
{
    public class Store : IEnumerable<Product>
    {
        private readonly IProductDatabase _database;

        public Store(IProductDatabase database)
        {
            _database = database;
        }

        public int Count { get => _database.Count; }

        public void Add(Product product)
        {
            _database.Add(product);
            _database.Save();
        }

        public void Remove(Product product)
        {
            _database.Remove(product);
            _database.Save();
        }

        public bool Contains(Product product)
        {
            return _database.Contains(product);
        }

        public List<Product> GetAll()
        {
            return _database.GetAll();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
