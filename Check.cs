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
    }
}
