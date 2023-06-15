using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count < StorageCapacity)
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            else
            {
                return "No more space in the storage room.";
            }
        }
        public int RemoveShoes(string material)
        {
            int shoesBeforeRemove = Shoes.Count;

            return Shoes.RemoveAll(x => x.Material == material);
        }
        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes
                .Where(x => x.Type.ToUpper() == type.ToUpper())
                .ToList();
        }
        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(x => x.Size == size);
        }
        public string StockList(double size, string type)
        {
            StringBuilder stock = new StringBuilder();

            var shoes = Shoes
                .Where(x => x.Size == size && x.Type == type)
                .ToList();

            if (shoes.Count == 0)
            {
                return "No matches found!";
            }

            stock.AppendLine($"Stock list for size {size} - {type} shoes:");

            foreach (var shoe in shoes)
            {
                stock.AppendLine(shoe.ToString());
            }

            return stock.ToString().TrimEnd();
        }
    }
}
