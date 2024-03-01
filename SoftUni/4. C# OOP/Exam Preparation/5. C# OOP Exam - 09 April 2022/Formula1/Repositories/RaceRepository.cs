using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        public IReadOnlyCollection<IRace> Models { get; private set; }

        public RaceRepository()
        {
            Models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            List<IRace> races = Models.ToList();

            races.Add(model);

            Models = races.AsReadOnly();
        }

        public IRace FindByName(string name)
        {
            return Models
              .FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            List<IRace> races = Models.ToList();

            bool isSuccesful = races.Remove(model);

            Models = races.AsReadOnly();

            return isSuccesful;
        }
    }
}
