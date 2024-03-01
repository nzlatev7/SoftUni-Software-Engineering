using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        public StudentRepository()
        {
            Models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models  { get; private set; }

        public void AddModel(IStudent model)
        {
            List<IStudent> models = Models.ToList();

            models.Add(model);

            Models = models.AsReadOnly();
        }

        public IStudent FindById(int id)
        {
            return Models
                .FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] data = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstName = data[0];
            string lastName = data[0];

            return Models
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
