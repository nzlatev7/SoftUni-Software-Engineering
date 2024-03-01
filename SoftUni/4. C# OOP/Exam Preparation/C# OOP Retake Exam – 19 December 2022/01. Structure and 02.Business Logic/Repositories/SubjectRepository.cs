using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        public SubjectRepository()
        {
            Models = new List<ISubject>().AsReadOnly();
        }

        public IReadOnlyCollection<ISubject> Models { get; private set; }

        public void AddModel(ISubject model)
        {
            List<ISubject> models = Models.ToList();

            models.Add(model);

            Models = models.AsReadOnly();
        }

        public ISubject FindById(int id)
        {
            return Models
                .FirstOrDefault(x => x.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return Models
                .FirstOrDefault(x => x.Name == name);
        }
    }
}
