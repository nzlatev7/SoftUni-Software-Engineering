using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomORM
{
    public class ReflectionHelper
    {
        public static void ReplaceBackingField(object sourceObj, string propertyName, object targetValue)
        {
            var backingField = sourceObj.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.SetField)
                .First(fi => fi.Name == $"<{propertyName}>k_BackingField");

            backingField.SetValue(sourceObj, targetValue);
        }
    }
}
