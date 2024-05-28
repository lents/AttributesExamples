using CreditCard;
using System.ComponentModel.DataAnnotations;

public class PaymentModel
{
    [Required]
    [CreditCardNumber]
    public string CardNumber { get; set; }

    // Other properties like CardHolderName, ExpiryDate, etc.
}

