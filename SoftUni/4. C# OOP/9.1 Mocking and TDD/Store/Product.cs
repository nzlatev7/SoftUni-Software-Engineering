using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad
{
    public class Product
    {
        public Product(int id, string label, decimal price, int quantity)
        {
            Id = id;
            Label = label;
            Price = price;
            Quantity = quantity;    
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
