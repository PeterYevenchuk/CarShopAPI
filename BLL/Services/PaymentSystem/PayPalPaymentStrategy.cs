﻿using BLL.Helpers.EmailValidation;

namespace BLL.Services.PaymentSystem;

public class PayPalPaymentStrategy : IPaymentStrategy
{
    public string ProcessPayment(decimal amount, string payPalMail)
    {
        if (EmailValid.IsValidEmail(payPalMail))
        {
            return $"Payment of {amount} via PayPal processed successfully.";
        }
        else
        {
            return $"The payment did not go through, the email {payPalMail} is invalid!";
        }
    }
}
