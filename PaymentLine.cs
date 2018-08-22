using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class PaymentLine
    {
        public Payment PaymentOption { get; set; }
        public double Amount { get; set; }

        public PaymentLine(Payment option, double amount)
        {
            PaymentOption = option;
            Amount = amount;
        }
    }
}
