using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomAttribute : Attribute
    {
        //public static void IsNullOrWhiteSpace(string message)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //    {
        //        throw new ArgumentException(ExceptionMessages.FirstNameNull);
        //    }

        //}
    }
}
