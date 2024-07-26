using System.Reflection;

// Step 2: Apply the custom attribute to the module
[module: ModuleInfo("This module contains the main logic for the application.")]
namespace ModuleAttributeDemo
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Program started.");
            PrintModuleInfo();
        }

        private static void PrintModuleInfo()
        {
            Module module = typeof(Program).Module;
            var attributes = module.GetCustomAttributes(typeof(ModuleInfoAttribute), false);
            if (attributes.Length > 0)
            {
                var moduleInfoAttribute = (ModuleInfoAttribute)attributes[0];
                Console.WriteLine($"Module Description: {moduleInfoAttribute.Description}");
            }
        }
    }
}
