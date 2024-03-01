using System;
using System.Collections.Generic;
using System.Text;

namespace _6
{
    public class Citizen : IIdentified, IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public int Age { get; private set; }   

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
