using System;
using System.Collections.Generic;
using System.Linq;

namespace _5
{
    public class Player
    {
        private string name;
        //private List<Stat> stats;

        public Player(string name, Stat stats)
        {
            Name = name;
            Stats = stats;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public Stat Stats { get; set; }

        public double SkillLevel { get => Stats.SkillLevel; }
    }
}