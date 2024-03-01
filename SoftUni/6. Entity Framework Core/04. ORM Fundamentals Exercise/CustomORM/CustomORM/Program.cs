
using CustomORM;
using Microsoft.Data.SqlClient;
using System.Reflection;


Type personType = typeof(Person);

Console.WriteLine(personType.Name);
Console.WriteLine(personType.FullName);
Console.WriteLine(personType.CustomAttributes.First());

PropertyInfo propertyInfo = personType.GetProperty("Foods");

Console.WriteLine(propertyInfo.PropertyType.GetGenericArguments()[0].Name);
