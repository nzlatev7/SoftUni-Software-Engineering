using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public IReadOnlyCollection<IFormulaOneCar> Models { get; private set; }

        public FormulaOneCarRepository()
        {
            Models = new List<IFormulaOneCar>();
        }

        public void Add(IFormulaOneCar model)
        {
            List<IFormulaOneCar> oneCars = Models.ToList();

            oneCars.Add(model);

            Models = oneCars.AsReadOnly();
        }

        public IFormulaOneCar FindByName(string name)
        {
            return Models
                .FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            List<IFormulaOneCar> oneCars = Models.ToList();

            bool isSuccesful = oneCars.Remove(model);

            Models = oneCars.AsReadOnly();

            return isSuccesful;
        }
    }
}
