using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public abstract class Payment
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Payment(string name, double startingBalance)
        {
            Name = name;
            Balance = startingBalance;
        }

        public virtual void Pay(double amount)
        {
            double newBalance = Balance - amount;
            if (newBalance < 0) throw new Exception("Not enough funds!");
            else
            {
                Balance = newBalance;
            }
            
        }
            
        public virtual void AddBalance(double amount)
        {
            Balance += amount;
        }

        public virtual bool TryToPay(double amount)
        {
            return Balance - amount >= 0;
        }

        public abstract override string ToString();

        public virtual string GetBalanceInfo()
        {
            return $"Balance: ${Balance}";
        }
    }
}
