using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class Wallet
    {
        public ObservableCollection<Payment> PaymentMethods { get; set; }

        public Wallet()
        {
            PaymentMethods = new ObservableCollection<Payment>();
        }

        public void AddPaymentMethod(Payment p)
        {
            PaymentMethods.Add(p);
        }

        public void Remove(string text)
        {
            foreach (var payment in PaymentMethods)
            {
                if (payment.Name == text) {
                    PaymentMethods.Remove(payment);
                    return;
                }
            }
        }

        public Payment Get(int index)
        {
            try
            {
                return PaymentMethods[index];
            }
            catch
            {
                return null;
            }
        }
    }
}
