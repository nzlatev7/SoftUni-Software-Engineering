using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonDataContrainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        private static SingletonDataContrainer instance = new SingletonDataContrainer();
        private SingletonDataContrainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("../../../capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }
        public static SingletonDataContrainer Instance
        {
            get
            {
                return instance;
            }
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
