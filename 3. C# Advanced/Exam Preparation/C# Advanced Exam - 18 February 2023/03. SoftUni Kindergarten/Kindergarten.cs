using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }

        public int ChildrenCount { get { return Registry.Count; } }
        public bool AddChild(Child child)
        {
            if (Registry.Count >= Capacity)
            {
                return false;
            }

            Registry.Add(child);

            return true;
        }

        public bool RemoveChild(string childFullName)
        {
            Child childForRemove = Registry
                .FirstOrDefault(x => $"{x.FirstName} {x.LastName}" == childFullName);

            if (childForRemove == null)
            {
                return false;
            }

            Registry.Remove(childForRemove);

            return true;
        }

        public Child GetChild(string childFullName)
        {
            Child childForRemove = Registry
                .FirstOrDefault(x => $"{x.FirstName} {x.LastName}" == childFullName);

            if (childForRemove == null)
            {
                return null;
            }

            return childForRemove;
        }

        public string RegistryReport()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry
                .OrderByDescending(x => x.Age)
                .ThenBy(x => x.LastName)
                .ThenBy(x => x.FirstName))
            {
                report.AppendLine(child.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
