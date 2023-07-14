using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] namesOfFileds)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {className}");

            Type type = Type.GetType(className);
            object instance = Activator.CreateInstance(type);

            foreach (var fieldName in namesOfFileds)
            {
                FieldInfo field = type.GetField(fieldName, (BindingFlags)60);

                string fieldValue = field.GetValue(instance).ToString();

                sb.AppendLine($"{fieldName} = {fieldValue}");        
            }

            return sb.ToString();
        }
    }
}
