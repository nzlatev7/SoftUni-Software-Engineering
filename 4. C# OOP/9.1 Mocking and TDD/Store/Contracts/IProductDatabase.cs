using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad.Contracts
{
    public interface IProductDatabase
    {
        public int Count { get; set; }

        public void Save();

        public void Add(Product product);

        public void Remove(Product product);

        public bool Contains(Product product);

        public List<Product> GetAll();
    }
}
