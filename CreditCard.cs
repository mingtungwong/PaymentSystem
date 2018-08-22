using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class CreditCard : Payment
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public double Limit { get; set; }

        public CreditCard(string name, double start, string cardHolderName, string cardNumber, string exp, double limit) : base(name, start)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            Expiration = exp;
            Limit = limit;
        }

        public override void AddBalance(double amount)
        {
            Balance -= amount;
        }

        public override void Pay(double amount)
        {
            double newBalance = Balance + amount;
            if (newBalance > Limit) throw new Exception("You are over your spending limit!");
            else
            {
                Balance = newBalance;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Payment Type: Credit Card\n");
            sb.Append($"Payment Name: {Name}\n");
            sb.Append($"Name: {CardHolderName}\n");
            sb.Append($"Number: XXXXX-XXXX-XXXX-{CardNumber.Substring(11)}\n");
            sb.Append($"Expiration: {Expiration}\n");
            sb.Append($"Limit: ${Limit}\n");
            sb.Append($"Balance: ${Balance}\n");
            sb.Append($"Available Credit: ${Limit - Balance}\n");
            return sb.ToString();
        }

        public override string GetBalanceInfo()
        {
            return $"Limit: ${Limit}\nBalance: ${Balance}\nAvailable Credit: ${Limit - Balance}";
        }
    }
}
