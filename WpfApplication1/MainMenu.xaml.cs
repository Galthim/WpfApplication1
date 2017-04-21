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
        
            }

        private void Summary_Click(object sender, RoutedEventArgs e)
        {
            Summary_Report Get_Summary = new Summary_Report();
            ShowBox.Navigate(Get_Summary);
        }
    }
}
