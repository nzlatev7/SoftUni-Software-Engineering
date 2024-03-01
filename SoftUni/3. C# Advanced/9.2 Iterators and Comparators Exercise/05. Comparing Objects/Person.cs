using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            int nameComparison = Name.CompareTo(other.Name);

            if (nameComparison == 0)
            {
                int ageComparison = Age.CompareTo(other.Age);

                if (ageComparison == 0)
                {
                    return Town.CompareTo(other.Town);
                }

                return ageComparison;
            }

            return nameComparison;
        }
    }
}
