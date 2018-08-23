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
    /// Interaction logic for PastTransactionWindow.xaml
    /// </summary>
    public partial class PastTransactionWindow : Window
    {
        public PastTransactionWindow(Transaction t)
        {
            InitializeComponent();
            TransactionInfo.Text = t.ToString();
        }

        private void ClosePastTransactionViewButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
