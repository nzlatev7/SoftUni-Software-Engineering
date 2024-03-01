using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int InitialInterestRate = 1;
        private const double InitialAmount = 10_000;

        public StudentLoan() 
            : base(InitialInterestRate, InitialAmount)
        {
        }
    }
}
