using System.Text.Json;

namespace JsonSerialize
{
    internal partial class Program
    {

        public static void Main()
        {
            var address = new Address
            {
                Street = "123 Main St",
                City = "Anytown",
                Country = "USA"
            };

            var person = new Person
            {
                Name = "Alice",
                Age = 30,
                Email = "alice@example.com",
                Address = address
            };

            var company = new Company
            {
                Name = "TechCorp",
                Industry = "Technology",
                Location = address
            };
            string json = JsonSerializer.Serialize(person);
            Console.WriteLine(json);

            var deserializedPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(deserializedPerson.Name);           

            // Serialize objects using the source-generated context
            string personJson = JsonSerializer.Serialize(person, MyJsonContext.Default.Person);
            Console.WriteLine("Person JSON:");
            Console.WriteLine(personJson);

            string companyJson = JsonSerializer.Serialize(company, MyJsonContext.Default.Company);
            Console.WriteLine("Company JSON:");
            Console.WriteLine(companyJson);

            // Deserialize objects using the source-generated context
            deserializedPerson = JsonSerializer.Deserialize(personJson, MyJsonContext.Default.Person);
            Console.WriteLine("\nDeserialized Person:");
            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}, Email: {deserializedPerson.Email}");

            var deserializedCompany = JsonSerializer.Deserialize(companyJson, MyJsonContext.Default.Company);
            Console.WriteLine("\nDeserialized Company:");
            Console.WriteLine($"Name: {deserializedCompany.Name}, Industry: {deserializedCompany.Industry}");           
        }
    }

}