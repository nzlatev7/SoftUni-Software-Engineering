using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        public IReadOnlyCollection<IPilot> Models { get; private set; }

        public PilotRepository()
        {
            Models = new List<IPilot>();
        }

        public void Add(IPilot model)
        {
            List<IPilot> pilots = Models.ToList();

            pilots.Add(model);

            Models = pilots.AsReadOnly();
        }

        public IPilot FindByName(string name)
        {
            return Models
               .FirstOrDefault(x => x.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            List<IPilot> pilots = Models.ToList();

            bool isSuccesful = pilots.Remove(model);

            Models = pilots.AsReadOnly();

            return isSuccesful;
        }
    }
}
