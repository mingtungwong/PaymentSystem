using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class TransactionLine
    {
        public string ItemName { get; set; }
        public double ItemCost { get; set; }

        public TransactionLine(string itemName, double itemCost)
        {
            ItemName = itemName;
            ItemCost = itemCost;
        }
    }
}
