using BLL.Helpers.CardNumberValidation;

namespace BLL.Services.PaymentSystem;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public string ProcessPayment(decimal amount, string cardNumber)
    {
        if (ValidCardNumber.ValidNumCard(cardNumber))
        {
            return $"Payment of {amount} via Credit Card processed successfully.";
        }
        else
        {
            return $"The payment did not go through, the card number {cardNumber} is incorrect!";
        }
    }
}
