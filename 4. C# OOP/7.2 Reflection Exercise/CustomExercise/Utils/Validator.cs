using CustomExer.Attributes;
using CustomExer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomExer.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        { 
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> attributes = property.GetCustomAttributes()
                    .Where(x => typeof(MyValidationAttribute)
                        .IsAssignableFrom(x.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        throw new ValidationExeption(100, "Invalid Parameter");
                    }
                }
            }

            return true;
        }
    }
}
