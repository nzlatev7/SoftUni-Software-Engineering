using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;

            Cal = new List<int>();
        }

        public List<int> Cal { get; set; }

        public override SandwichPrototype Clone()
        {
            string ingredientList = GetIngredientList();
            Console.WriteLine("Cloning sandwich with ingredients: {0}", ingredientList);

            return (SandwichPrototype)MemberwiseClone();
        }

        public override SandwichPrototype DeepCopy()
        {
            var sandwichCopy = MemberwiseClone() as Sandwich;

            sandwichCopy.Cal = new List<int>();

            return sandwichCopy;
        }

        private string GetIngredientList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
