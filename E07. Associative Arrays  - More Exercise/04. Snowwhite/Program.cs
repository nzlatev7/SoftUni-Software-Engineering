using System;
using System.Collections.Generic;
using System.Linq;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();
            string command;
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] data = command.Split(" <:> ");
                string dwarfName = data[0];
                string dwarfHatColor = data[1];
                int dwarfPhysics = int.Parse(data[2]);

                Dwarf dwarf = new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics);

                Dwarf dwarfChecking = dwarfs.Where(x => x.DwarfName == dwarfName && x.DwarfHatColor == dwarfHatColor).FirstOrDefault();
                if (dwarfChecking != null)
                {
                    if (dwarfPhysics > dwarfChecking.DwarfPhysics)
                    {
                        dwarfs.Remove(dwarfChecking);
                        dwarfs.Add(dwarf);
                    }
                }
                else
                {
                    dwarfs.Add(dwarf);
                }
            }
            //You must order the dwarfs by physics in descending order and then by the total count of dwarfs with the same hat color in descending order
            foreach (var dwarf in dwarfs.OrderByDescending(x => x.DwarfPhysics).ThenByDescending(x => dwarfs.Count(d => x.DwarfHatColor == d.DwarfHatColor)))
            {
                Console.WriteLine($"({dwarf.DwarfHatColor}) {dwarf.DwarfName} <-> {dwarf.DwarfPhysics}");
            }
        }
    }
    class Dwarf
    {
        public Dwarf(string dwarfName, string dwarfHatColor, int dwarfPhysics)
        {
            DwarfName = dwarfName;
            DwarfHatColor = dwarfHatColor;
            DwarfPhysics = dwarfPhysics;
        }
        public string DwarfName { get; set; }
        public string DwarfHatColor { get; set; }
        public int DwarfPhysics { get; set; }
    }
}