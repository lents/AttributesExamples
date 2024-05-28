using System.ComponentModel.DataAnnotations;

namespace CreditCard
{
    public class CreditCardNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Credit card number is required.");
            }
            var cardNumber = value.ToString();
            if (IsValidCreditCardNumber(cardNumber))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid credit card number.");
        }

        private bool IsValidCreditCardNumber(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                char[] nx = cardNumber.ToCharArray();
                int n;
                if (!int.TryParse(nx[i].ToString(), out n))
                {
                    return false;
                }

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }

                sum += n;
                alternate = !alternate;
            }

            return (sum % 10 == 0);
        }
    }

}
