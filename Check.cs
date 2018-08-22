using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class Check : Payment
    {
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }

        public Check(string name, double start, string accountNumber, string routingNumber) : base(name, start)
        {
            AccountNumber = accountNumber;
            RoutingNumber = routingNumber;
        }

        public override string ToString()
        {
            return $"Payment Type: Check\nName: {Name}\nAccount Number: {AccountNumber}\nRouting Number: {RoutingNumber}\nBalance: ${Balance}";
        }
    }
}
