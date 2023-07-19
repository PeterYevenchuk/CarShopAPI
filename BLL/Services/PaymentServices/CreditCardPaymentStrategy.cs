using BLL.Helpers.CardNumberValidation;

namespace BLL.Services.PaymentSystem;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public string ProcessPayment(decimal amount, string cardNumber)
    {
        if (ValidCardNumber.ValidNumCard(cardNumber))
        {
            // connect to bank Api if all goot return this
            return $"Payment of {amount} via Credit Card processed successfully.";
        }
        else
        {
            return $"The payment did not go through, the card number {cardNumber} is incorrect!";
        }
    }
}
