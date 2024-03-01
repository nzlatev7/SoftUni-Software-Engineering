using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        public VesselRepository()
        {
            Models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models { get; private set; }

        public void Add(IVessel model)
        {
            List<IVessel> vessels = Models.ToList();

            vessels.Add(model);
            Models = vessels.AsReadOnly();
        }

        public IVessel FindByName(string name)
        {
            return Models
                .FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            List<IVessel> vessels = Models.ToList();

            bool isDeleted = vessels.Remove(model);

            Models = vessels.AsReadOnly();

            return isDeleted;
        }
    }
}
