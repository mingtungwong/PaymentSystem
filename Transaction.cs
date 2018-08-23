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
        private readonly StringBuilder itemsBuilder = new StringBuilder();
        private readonly StringBuilder paymentsBuilder = new StringBuilder();

        public Transaction(string name)
        {
            TransactionIDNumber = TransactionIDCounter++;
            TransactionName = name;
            Items = new ObservableCollection<TransactionLine>();
            Payments = new ObservableCollection<PaymentLine>();
            itemsBuilder.Append("\nItems\n\n");
            paymentsBuilder.Append("\n\nPayments\n\n");
        }

        public void AddItem(TransactionLine item)
        {
            Items.Add(item);
            itemsBuilder.Append($"{item.ItemName}\t\t\t${item.ItemCost}\n");
        }

        public void AddPayment(PaymentLine payment)
        {
            Payments.Add(payment);
            paymentsBuilder.Append($"{payment.PaymentOption.Name}\t\t\t${payment.Amount}\n");
        }
        
        public double GetTotalBalance()
        {
            double sum = 0;
            foreach(var item in Items)
            {
                sum += item.ItemCost;
            }
            return sum;
        }

        public double GetTotalFunds()
        {
            double sum = 0;
            foreach(var payment in Payments)
            {
                sum += payment.Amount;
            }
            return sum;
        }

        public bool HaveEnoughFunds()
        {
            foreach(var payment in Payments)
            {
                if (!payment.PaymentOption.TryToPay(payment.Amount)) return false;
            }
            return true;
        }

        public void Charge()
        {
            foreach(var payment in Payments)
            {
                payment.PaymentOption.Pay(payment.Amount);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double balance = GetTotalBalance();
            double funds = GetTotalFunds();
            sb.Append($"\t\tTotal:\t${balance}\n");
            sb.Append($"\t\tPaid:\t${funds}\n");
            sb.Append($"\t\tDue:\t${balance - funds}\n");
            return $"{TransactionName} (ID#{TransactionIDNumber})\n{itemsBuilder.ToString()}{paymentsBuilder.ToString()}\n{sb.ToString()}";
        }
    }
}
