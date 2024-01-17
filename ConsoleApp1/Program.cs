using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Get all types in the 'System' namespace from mscorlib
            var systemTypes = Assembly.GetAssembly(typeof(int)) // typeof(int) is just a simple way to get mscorlib
                                .GetTypes()
                                .Where(t => t.Namespace != null && t.Namespace.StartsWith("System"))
                                .OrderBy(t => t.Namespace).ThenBy(t => t.Name);

            foreach (var type in systemTypes)
            {   Console.WriteLine($"{type}");
                if (type.ToString().Contains("Console"))
                {
                    Console.WriteLine($"{type.Namespace}.{type.Name}");
                }
            }
        }
    }
}
