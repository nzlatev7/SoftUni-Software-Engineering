using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        { 
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties()
                .Where(p => p.CustomAttributes
                    .Any(a => typeof(MyValidationAttribute).IsAssignableFrom(a.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> attributes = property.GetCustomAttributes()
                    .Where(a => typeof(MyValidationAttribute).IsAssignableFrom(a.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.IsValid(property.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
