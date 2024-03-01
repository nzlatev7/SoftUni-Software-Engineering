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
            var dragons = new Dictionary<string, List<Dragon>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //"{type} {name} {damage} {health} {armor}"
                string[] data = Console.ReadLine().Split();

                string type = data[0];
                string name = data[1];
                string damage = data[2];
                string health = data[3];
                string armor = data[4];

                //checking if we receive num or null
                int currDamage = CheckForNull(damage, 2);
                int currHealth = CheckForNull(health, 3);
                int currArmor = CheckForNull(armor, 4);

                if (dragons.ContainsKey(type) && dragons[type].Any(x => x.Name == name))
                {
                    //1. one option - to get the index of our dragon we want to change
                    //int index = dragons[type].FindIndex(x => x.Name == name);
                    //dragons[type][index].Damage = currDamage;
                    //dragons[type][index].Health = currHealth;
                    //dragons[type][index].Armor = currArmor;
                    //continue;

                    //2.second option - to get the dragon and chage his properties
                    var drogonForUpdate = dragons[type].Find(x => x.Name == name);
                    drogonForUpdate.Damage = currDamage;
                    drogonForUpdate.Health = currHealth;
                    drogonForUpdate.Armor = currArmor;//???nz dali she se promeni
                    continue;
                }
                //validate if we have that type
                if (dragons.ContainsKey(type))
                {
                    Dragon dragon1 = new Dragon(name, currDamage, currHealth, currArmor);
                    dragons[type].Add(dragon1);
                    continue;
                }
                Dragon dragon = new Dragon(name, currDamage, currHealth, currArmor);
                List<Dragon> dragonsList = new List<Dragon>();
                dragonsList.Add(dragon);
                dragons.Add(type, dragonsList);
            }
            foreach (var x in dragons)
            {
                Console.WriteLine($"{x.Key}::({x.Value.Select(x => x.Damage).Average():f2}/" +
                    $"{x.Value.Select(x => x.Health).Average():f2}/" +
                    $"{x.Value.Select(x => x.Armor).Average():f2})");
                foreach (var dragon in dragons[x.Key].OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
        static int CheckForNull(string x, int index)
        {
            int num;
            if (x == "null" && index == 2)
            {
                //damage
                num = 45;
            }
            else if (x == "null" && index == 3)
            {
                //health
                num = 250;
            }
            else if (x == "null" && index == 4)
            {
                //armor
                num = 10;
            }
            else
            {
                num = int.Parse(x);
            }
            return num;
        }
    }
    public class Dragon
    {
        public Dragon(string name, int damage, int health, int armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}