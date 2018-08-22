using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class Cash : Payment
    {
        public Cash(string name, double startBal) : base(name, startBal)
        {

        }

        public override string ToString()
        {
            return $"Payment Type: Cash\nPayment Name: {Name}\nBalance: ${Balance}";
        }
    }
}
