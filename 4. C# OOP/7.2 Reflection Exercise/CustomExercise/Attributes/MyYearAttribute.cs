using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExer.Attributes
{
    public class MyYearAttribute : MyValidationAttribute
    {
        private int _year;
        public MyYearAttribute(int year)
        {
            _year = year;
        }

        public override bool IsValid(object value)
        {
            if (!int.TryParse(value.ToString(), out int year))
            {
                return false;
            }

            if (year < _year)
            {
                return false;
            }

            return true;
        }
    }
}
