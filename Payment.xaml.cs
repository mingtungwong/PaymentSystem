using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaymentSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Wallet MyWallet { get; set; }
        public Transaction Current { get; set; }
        public AddPaymentWindow addPayWin;
        private List<Control> transactionUIElements;

        public MainWindow()
        {
            MyWallet = new Wallet();
            addPayWin = new AddPaymentWindow(MyWallet);
            InitializeComponent(); 
            transactionUIElements = getTransactionUIElements();
            ToggleTransactionUIVisibility(false);
            SavedPaymentsDropdown.ItemsSource = MyWallet.PaymentMethods;
            PaymentSourceDropdown.ItemsSource = MyWallet.PaymentMethods;
            SavedPaymentsDropdown.DisplayMemberPath = "Name";
            PaymentSourceDropdown.DisplayMemberPath = "Name";
            SavedPaymentsDropdown.SelectedIndex = 0;
            PaymentSourceDropdown.SelectedIndex = 0;

        }

        private List<Control> getTransactionUIElements()
        {
            List<Control> list = new List<Control>();
            list.Add(AddItemsLabel);
            list.Add(ItemNameLabel);
            list.Add(ItemNameInput);
            list.Add(TransactionItemPriceLabel);
            list.Add(TransactionItemPriceInput);
            list.Add(AddItemButton);
            list.Add(AddPaymentsLabel);
            list.Add(PaymentSourceLabel);
            list.Add(PaymentSourceDropdown);
            list.Add(PaymentAmountLabel);
            list.Add(PaymentAmountInput);
            list.Add(AddPaymentSourceButton);
            list.Add(TotalBalanceLabel);
            list.Add(TotalBalanceAmountLabel);
            list.Add(TotalFundsLabel);
            list.Add(TotalFundsAmountLabel);
            list.Add(PayButton);
            return list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addPayWin.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Payment p = MyWallet.Get(SavedPaymentsDropdown.SelectedIndex);
            PaymentInfo.Text = p != null ? p.ToString() : "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string text = SavedPaymentsDropdown.Text;
            MyWallet.Remove(text);
        }

        private void AddFundsButton_Click(object sender, RoutedEventArgs e)
        {
            Payment p = MyWallet.Get(SavedPaymentsDropdown.SelectedIndex);
            if(p != null)
            {
                AddFundsWindow win = new AddFundsWindow(p);
                win.Visibility = Visibility.Visible;
            }
        }

        private void ToggleTransactionUIVisibility(bool showUI)
        {
            Visibility vis = showUI ? Visibility.Visible : Visibility.Hidden;
            foreach(var c in transactionUIElements)
            {
                c.Visibility = vis;
            }
        }

        private void SetTransactionNameButton_Click(object sender, RoutedEventArgs e)
        {
            string transactionName = TransactionNameInput.Text;
            TransactionNameInput.IsEnabled = false;
            SetTransactionNameButton.Visibility = Visibility.Hidden;
            ToggleTransactionUIVisibility(true);
            Current = new Transaction(transactionName);
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            string itemName = ItemNameInput.Text;
            double price = double.Parse(TransactionItemPriceInput.Text);
            Current.AddItem(new TransactionLine(itemName, price));
            ItemNameInput.Text = "";
            TransactionItemPriceInput.Text = "";
            TotalBalanceAmountLabel.Content = $"${Current.GetTotalBalance()}";
            if(TransactionGrid.ItemsSource == null)
            {
                TransactionGrid.ItemsSource = Current.Items;
                PaymentGrid.ItemsSource = Current.Payments;
            }
        }

        private void AddPaymentSourceButton_Click(object sender, RoutedEventArgs e)
        {
            Payment p = MyWallet.Get(PaymentSourceDropdown.SelectedIndex);
            double amount = double.Parse(PaymentAmountInput.Text);
            Current.AddPayment(new PaymentLine(p, amount));
            PaymentAmountInput.Text = "";
            TotalFundsAmountLabel.Content = $"${Current.GetTotalFunds()}";
            if (TransactionGrid.ItemsSource == null)
            {
                TransactionGrid.ItemsSource = Current.Items;
                PaymentGrid.ItemsSource = Current.Payments;
            }
        }
    }
}
