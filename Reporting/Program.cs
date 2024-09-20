namespace Reporting
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

   
    // Step 1: Define the custom attribute
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class ReportFieldAttribute : Attribute
    {
        public string DisplayName { get; }
        public ReportFieldAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    // Step 2: Apply the custom attribute
    public class Employee
    {
        [ReportField("Employee ID")]
        public int Id { get; set; }

        [ReportField("First Name")]
        public string FirstName { get; set; }

        [ReportField("Last Name")]
        public string LastName { get; set; }

        [ReportField("Email Address")]
        public string Email { get; set; }
        [ReportField("Age")]
        public int Age { get; set; } // Not included in the report
    }

    // Step 3: Create the reporting tool
    public static class ReportGenerator
    {
        public static void GenerateReport<T>(IEnumerable<T> items)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            // Print header
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(ReportFieldAttribute)) as ReportFieldAttribute;
                if (attribute != null)
                {
                    Console.Write($"{attribute.DisplayName}\t");
                }
            }
            Console.WriteLine();

            // Print rows
            foreach (var item in items)
            {
                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttribute(typeof(ReportFieldAttribute)) as ReportFieldAttribute;
                    if (attribute != null)
                    {
                        Console.Write($"{property.GetValue(item)}\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    // Step 4: Demonstrate the code in action
    public class Program
    {
        public static void Main()
        {
            var employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Age = 30 },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Age = 25 }
        };

            ReportGenerator.GenerateReport(employees);
        }
    }

}
