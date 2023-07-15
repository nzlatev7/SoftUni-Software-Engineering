using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{    
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            Type type = obj.GetType();

            if (!int.TryParse(obj.ToString(), out int age))
            {
                return false;
            }

            if (age < minValue || age > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
