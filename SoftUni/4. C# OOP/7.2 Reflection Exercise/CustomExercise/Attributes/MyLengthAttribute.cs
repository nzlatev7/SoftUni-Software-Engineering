using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExer.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyLengthAttribute : MyValidationAttribute
    {
        private int _minLength;
        private int _maxLength;
        public MyLengthAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            return value.ToString().Length >= _minLength && 
                value.ToString().Length <=_maxLength;
        }
    }
}
