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
    }
}
