using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        public UniversityRepository()
        {
            Models = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models { get; private set; }

        public void AddModel(IUniversity model)
        {
            List<IUniversity> models = Models.ToList();

            models.Add(model);

            Models = models.AsReadOnly();
        }

        public IUniversity FindById(int id)
        {
            return Models
                .FirstOrDefault(x => x.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return Models
                .FirstOrDefault(x => x.Name == name);
        }
    }
}
