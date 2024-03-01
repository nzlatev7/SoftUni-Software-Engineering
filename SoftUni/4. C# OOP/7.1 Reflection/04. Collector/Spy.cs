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
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods
                .Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods
                .Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var item in methods)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo field in fields)
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            PropertyInfo[] properties = type.GetProperties();

            foreach (var prop in properties)
            {
                if (!prop.CanRead)
                {
                    sb.AppendLine($"{prop.Name} have to be public!");
                }

                if (prop.CanWrite)
                {
                    sb.AppendLine($"{prop.Name} have to be private!");
                }
            }

            return sb.ToString();
        }

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
