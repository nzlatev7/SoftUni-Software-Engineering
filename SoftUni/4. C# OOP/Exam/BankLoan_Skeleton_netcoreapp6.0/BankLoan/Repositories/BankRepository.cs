using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        public BankRepository()
        {
            Models = new List<IBank>();
        }
        public IReadOnlyCollection<IBank> Models { get; private set; }

        public void AddModel(IBank model)
        {
            List<IBank> banks = Models.ToList();

            banks.Add(model);
            Models = banks.AsReadOnly();
        }

        public IBank FirstModel(string name)
        {
            return Models
                .FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(IBank model)
        {
            List<IBank> banks = Models.ToList();

            bool isRemoved = banks.Remove(model);
            Models = banks.AsReadOnly();

            return isRemoved;
        }
    }
}
