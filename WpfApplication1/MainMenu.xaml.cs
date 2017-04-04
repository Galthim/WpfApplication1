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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void EnterInvoice_Button_Click(object sender, RoutedEventArgs e)
        {
            EnterInvoice Enter = new EnterInvoice();
            ShowBox.Navigate(Enter);
        }

        private void GetInvoice_Button_Click(object sender, RoutedEventArgs e)
        {
            Retrieve_Invoice GetInvoice = new Retrieve_Invoice();
            ShowBox.Navigate(GetInvoice);
            int[] Getting_Data = WpfApplication1.ServerConnect.Find_Invoice_Data();
            if (Getting_Data != null)
            {
                for (int x = 0; x <= Getting_Data.Length -1; x++)
                {
                    GetInvoice.ComboBox_Invoice.Items.Add(Getting_Data[x]);
                }
            }
            }
    }
}
