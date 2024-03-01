using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExer.Exceptions
{
    public class ValidationExeption : Exception
    {
        public ValidationExeption(int erorCode, string message)
            : base(message)
        {
            ErrorCode = erorCode;
        }

        public int ErrorCode { get; }
    }
}
