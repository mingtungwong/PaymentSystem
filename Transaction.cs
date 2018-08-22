using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class Transaction
    {
        public static int TransactionIDCounter = 1;
        public ObservableCollection<TransactionLine> Items { get; set; }
        public ObservableCollection<PaymentLine> Payments { get; set; }
        public string TransactionName { get; set; }
        public int TransactionIDNumber { get; set; }

        public Transaction(string name)
        {
            TransactionIDNumber = TransactionIDCounter++;
            TransactionName = name;
            Items = new ObservableCollection<TransactionLine>();
            Payments = new ObservableCollection<PaymentLine>();
        }

        public void AddItem(TransactionLine item)
        {
            Items.Add(item);
        }

        public void AddPayment(PaymentLine payment)
        {
            Payments.Add(payment);
        }
        
    }
}
