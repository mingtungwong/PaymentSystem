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
        public AddPaymentWindow addPayWin;

        public MainWindow()
        {
            MyWallet = new Wallet();
            addPayWin = new AddPaymentWindow(MyWallet);
            InitializeComponent();
            SavedPaymentsDropdown.ItemsSource = MyWallet.PaymentMethods;
            SavedPaymentsDropdown.DisplayMemberPath = "Name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addPayWin.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string text = SavedPaymentsDropdown.Text;
            MyWallet.Remove(text);
        }
    }
}
