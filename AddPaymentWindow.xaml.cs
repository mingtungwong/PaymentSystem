using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PaymentSystem
{
    /// <summary>
    /// Interaction logic for AddPaymentWindow.xaml
    /// </summary>
    public partial class AddPaymentWindow : Window
    {
        private string[] PaymentOptions = { "Cash", "Credit", "Check" };
        public string selection;
        public Wallet theWallet;
        private Visibility Hidden = Visibility.Hidden;
        private Visibility Visible = Visibility.Visible;

        public AddPaymentWindow(Wallet wallet)
        {
            theWallet = wallet;
            InitializeComponent();
            PaymentOptionTypes.ItemsSource = PaymentOptions;
            PaymentOptionTypes.SelectedIndex = 0;
            InitView();
        }

        private void InitView()
        {
            MainLabel.Visibility = Visibility.Hidden;
            SecondaryLabel.Visibility = Visibility.Hidden;
            MainInfo.Visibility = Visibility.Hidden;
            SecondaryInfo.Visibility = Visibility.Hidden;
            CCNameLabel.Visibility = Hidden;
            CCNAmeInput.Visibility = Hidden;
            LimitInput.Visibility = Hidden;
            LimitLabel.Visibility = Hidden;
        }

        private void PaymentOptionTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selection = PaymentOptionTypes.SelectedItem.ToString();
            switch (selection)
            {
                case "Cash": InitView(); break;
                case "Credit": CreditOrCheckView(true); break;
                case "Check": CreditOrCheckView(false); break;
            }
        }

        private void CreditOrCheckView(bool isCreditView)
        {
            MainLabel.Content = isCreditView ? "Card Number" : "Account Number";
            MainLabel.Visibility = Visible;
            SecondaryLabel.Content = isCreditView ? "Expiration" : "Routing Number";
            SecondaryLabel.Visibility = Visible;
            MainInfo.Visibility = Visible;
            SecondaryInfo.Visibility = Visible;
            CCNameLabel.Visibility = isCreditView ? Visible : Hidden;
            CCNAmeInput.Visibility = isCreditView ? Visible : Hidden;
            LimitInput.Visibility = isCreditView ? Visible : Hidden;
            LimitLabel.Visibility = isCreditView ? Visible : Hidden;

        }

        private Payment FetchAndCreateCashPayment(string name, double balance)
        {
            return new Cash(name, balance);
        }

        private Payment FetchAndCreateCreditPayment(string name, double balance)
        {
            string ccNumber = MainInfo.Text;
            string exp = SecondaryInfo.Text;
            string ccName = CCNAmeInput.Text;
            double ccLimit = double.Parse(LimitInput.Text);
            return new CreditCard(name, balance, ccName, ccNumber, exp, ccLimit);
        }

        private Payment FetchAndCreateCheckPayment(string name, double balance)
        {
            string accountNumber = MainInfo.Text;
            string routingNumber = SecondaryInfo.Text;
            return new Check(name, balance, accountNumber, routingNumber);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = PaymentNameInput.Text;
            double balance = double.Parse(StartingBalanceBox.Text);
            Payment p = null;

            switch (selection)
            {
                case "Cash": p = FetchAndCreateCashPayment(name, balance); break;
                case "Credit": p = FetchAndCreateCreditPayment(name, balance); break;
                case "Check": p = FetchAndCreateCheckPayment(name, balance); break;
            }
            theWallet.AddPaymentMethod(p);
            Cleanup();
            this.Visibility = Visibility.Hidden;
        }

        private void Cleanup()
        {
            PaymentNameInput.Text = "";
            StartingBalanceBox.Text = "";
            MainInfo.Text = "";
            SecondaryInfo.Text = "";
            PaymentOptionTypes.SelectedIndex = 0;
        }
    }
}
