using AuthorProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeTracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methods = type.GetMethods((BindingFlags)60);

            foreach (MethodInfo method in methods)
            {
                AuthorAttribute[] attributes = method
                    .GetCustomAttributes<AuthorAttribute>()
                    .ToArray();

                foreach (var attribure in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribure.Name}");
                }            
            }
            
        }
    }
}
