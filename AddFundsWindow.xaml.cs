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
    /// Interaction logic for AddFundsWindow.xaml
    /// </summary>
    public partial class AddFundsWindow : Window
    {
        private Payment selectedPayment;
        private TextBlock tbToUpdate;

        public AddFundsWindow(Payment p, TextBlock pi)
        {
            selectedPayment = p;
            tbToUpdate = pi;
            InitializeComponent();
            AddFundsAccountInfo.Text = p.GetBalanceInfo();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SubmitFunds_Click(object sender, RoutedEventArgs e)
        {
            var amountToAdd = double.Parse(FundsAmountInput.Text);
            selectedPayment.AddBalance(amountToAdd);
            tbToUpdate.Text = selectedPayment.ToString();
            this.Visibility = Visibility.Hidden;
        }
    }
}
