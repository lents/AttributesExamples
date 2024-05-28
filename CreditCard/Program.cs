using System.ComponentModel.DataAnnotations;

namespace CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var payment = new PaymentModel { CardNumber = "1234567812345670" };
            var context = new ValidationContext(payment, null, null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(payment, context, results, true);

            if (isValid)
            {
                Console.WriteLine("Credit card number is valid.");
            }
            else
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }
    }

}