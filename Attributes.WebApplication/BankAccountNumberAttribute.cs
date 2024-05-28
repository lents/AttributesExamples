using System.ComponentModel.DataAnnotations;

namespace Attributes.WebApplication
{
    public class BankAccountNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; 
            }

            string accountNumber = value.ToString();

            
            if (IsBankAccountNumberValid(accountNumber))
            {
                return ValidationResult.Success; 
            }
            else
            {
                return new ValidationResult("Invalid bank account number."); 
            }
        }

        private bool IsBankAccountNumberValid(string accountNumber)
        {
            
            return !string.IsNullOrEmpty(accountNumber) && accountNumber.Length == 20 && int.TryParse(accountNumber, out _);
        }
    }
}
