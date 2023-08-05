using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            Loans = new List<ILoan>();
            Clients = new List<IClient>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bank name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans { get; private set; } //???

        public IReadOnlyCollection<IClient> Clients { get; private set; } //???

        public void AddClient(IClient Client)
        {
            if (Capacity == Clients.Count)
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }

            List<IClient> clients = Clients.ToList();

            clients.Add(Client);
            Clients = clients.AsReadOnly();
        }

        public void AddLoan(ILoan loan)
        {
            List<ILoan> loans = Loans.ToList();

            loans.Add(loan);
            Loans = loans.AsReadOnly();
        }

        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();

            statistics.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            statistics.AppendLine($"Clients: {(Clients.Count == 0 ? "none" : string.Join(", ", Clients.Select(x => x.Name)))}");
            statistics.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {Loans.Sum(x => x.InterestRate)}");
        
            return statistics.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client)
        {
            List<IClient> clients = Clients.ToList();

            clients.Remove(Client);
            Clients = clients.AsReadOnly();
        }

        public double SumRates()
        {
            return Loans
                .Select(x => x.InterestRate)
                .Sum();
        }
    }
}
