using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _6ta
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        //override the GetHashCode method from the base class Object
        //making a tuple and get the hashCode
        public override int GetHashCode() => (Name, Age).GetHashCode();

        public override bool Equals(object other) =>
        other is Person p && (p.Name, p.Age).Equals((Name, Age));

        public int CompareTo([AllowNull] Person other)
        {
            int nameComparison = Name.CompareTo(other.Name);

            if (nameComparison == 0)
            {
                return Age.CompareTo(other.Age);
            }

            return nameComparison;
        }
    }
}
