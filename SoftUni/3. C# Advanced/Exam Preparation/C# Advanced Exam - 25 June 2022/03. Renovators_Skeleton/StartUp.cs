using System;
using System.Collections.Generic;

namespace Renovators
{
    public class StartUp
    {
        static void Main()
        {
            // Initialize the repository (Catalog)
            Catalog catalog = new Catalog("Quality renovators", 5, "Kitchen");

            Console.WriteLine(catalog.RemoveRenovator("gergi"));
            

        }
    }
}
