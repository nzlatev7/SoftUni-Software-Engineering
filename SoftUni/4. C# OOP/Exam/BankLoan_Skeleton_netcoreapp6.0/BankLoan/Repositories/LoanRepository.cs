using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        public LoanRepository()
        {
            Models = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models { get; private set; }

        public void AddModel(ILoan model)
        {
            List<ILoan> loans = Models.ToList();

            loans.Add(model);
            Models = loans.AsReadOnly();
        }

        public ILoan FirstModel(string name)
        {
            return Models
                .FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveModel(ILoan model)
        {
            List<ILoan> loans = Models.ToList();

            bool isRemoved = loans.Remove(model);
            Models = loans.AsReadOnly();

            return isRemoved;
        }
    }
}
