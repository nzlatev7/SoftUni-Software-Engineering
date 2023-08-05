using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ILoan> loans;
        private readonly IRepository<IBank> banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            IBank bank;

            switch (bankTypeName)
            {
                case nameof(BranchBank):
                    bank = new BranchBank(name);
                    break;
                case nameof(CentralBank):
                    bank = new CentralBank(name);
                    break;
                default:
                    throw new ArgumentException("Invalid bank type.");
            }

            banks.AddModel(bank);

            return $"{bankTypeName} is successfully added.";
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan;

            switch (loanTypeName)
            {
                case nameof(MortgageLoan):
                    loan = new MortgageLoan();
                    break;
                case nameof(StudentLoan):
                    loan = new StudentLoan();
                    break;
                default:
                    throw new ArgumentException("Invalid loan type.");
            }

            loans.AddModel(loan);

            return $"{loanTypeName} is successfully added.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank bank = banks.FirstModel(bankName);

            ILoan loan = loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }

            loans.RemoveModel(loan);
            bank.AddLoan(loan);

            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client;

            switch (clientTypeName)
            {
                case nameof(Student):
                    client = new Student(clientName, id, income);
                    break;
                case nameof(Adult):
                    client = new Adult(clientName, id, income);
                    break;
                default:
                    throw new ArgumentException("Invalid client type.");
            }

            IBank bank = banks.FirstModel(bankName);

            if (bank.GetType().Name == nameof(BranchBank) 
                && clientTypeName == nameof(Student))
            {
                bank.AddClient(client);
            }
            else if (bank.GetType().Name == nameof(CentralBank)
                && clientTypeName == nameof(Adult))
            {
                bank.AddClient(client);
            }
            else
            {
                return "Unsuitable bank.";
            }

            return $"{clientTypeName} successfully added to {bankName}.";
        }
       
        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);

            var funds = bank.Clients.Sum(x => x.Income) + bank.Loans.Sum(x => x.Amount);

            return $"The funds of bank {bankName} are {funds:f2}.";
        }

        public string Statistics()
        {
            StringBuilder statistics = new StringBuilder();

            foreach (var bank in banks.Models)
            {
                statistics.AppendLine(bank.GetStatistics());
            }

            return statistics.ToString().TrimEnd();
        }
    }
}
