using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;

            renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count { get { return renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }


            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator ren = renovators.Find(x => x.Name == name);

            return renovators.Remove(ren);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(x => x.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            Renovator ren = renovators.Find(x => x.Name == name);

            if (ren == null)
            {
                return null;
            }

            ren.Hired = true;

            return ren;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.Where(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder catalogInfo = new StringBuilder();

            catalogInfo.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in renovators
                .Where(x => x.Hired != true))
            {
                catalogInfo.AppendLine(renovator.ToString());
            }

            return catalogInfo.ToString().TrimEnd();
        }
    }
}
