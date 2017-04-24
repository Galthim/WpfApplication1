using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Summary_Report.xaml
    /// </summary>
    public partial class Summary_Report : Page
    {
        string[,] OrderNum = new string[2000, 2000];
        string[,] CustInfo = new string[2000, 2000];
        string[,] OrderInfo = new string[2155, 2155];
        string[,] ProdInfo = new string[2155, 2155];
        public Summary_Report()
        {
            InitializeComponent();

            try
            {

                int axe = 0;
                SqlDataReader DataGetter = null;
                SqlConnection Northwind = new SqlConnection("Server =Localhost;" + "Trusted_Connection = true;" + "Database =northwind;");
                Northwind.Open();
                SqlCommand myQuery = new SqlCommand("SELECT OrderID, CustomerID, OrderDate FROM Orders", Northwind);
                DataGetter = myQuery.ExecuteReader();


                while (DataGetter.Read())
                {
                    //Order ID number
                    OrderNum[axe, 0] = string.Empty + DataGetter.GetInt32(0);
                    //Customer ID number
                    OrderNum[axe, 1] = DataGetter.GetString(1);
                    //Order Date
                    OrderNum[axe, 2] = string.Empty + DataGetter.GetDateTime(2);

                    axe++;
                }
                for (int x = 0; x < axe; x++)
                {
                    From_Date.Items.Add(OrderNum[x, 2]);
                    Till_Date.Items.Add(OrderNum[x, 2]);
                }


                DataGetter.Close();
                SqlDataReader DataGetter2 = null;
                SqlCommand myQuery2 = new SqlCommand("SELECT CustomerID, ContactName, Address, City FROM Customers", Northwind);
                DataGetter2 = myQuery2.ExecuteReader();
                // AND  AND OrderID, ProductID, UnitPrice, Quantity FROM OrderDetails AND ProductID, ProductName FROM Products"
                axe = 0;
                while (DataGetter2.Read())
                {
                    //CustomerID to compare
                    CustInfo[axe, 0] = DataGetter2.GetString(0);
                    //ContactName                
                    CustInfo[axe, 1] = DataGetter2.GetString(1);
                    //Address                    
                    CustInfo[axe, 2] = DataGetter2.GetString(2);
                    //City                       
                    CustInfo[axe, 3] = DataGetter2.GetString(3);
                    axe++;
                }
                for (int x = 0; x < axe; x++)
                {
                    Customer_Combo.Items.Add(CustInfo[x, 1]);
                }
                DataGetter2.Close();

                SqlDataReader DataGetter3 = null;
                SqlCommand myQuery3 = new SqlCommand("SELECT OrderID, ProductID, UnitPrice, Quantity FROM [Order Details]", Northwind);
                DataGetter3 = myQuery3.ExecuteReader();
                // ProductID, ProductName FROM Products
                axe = 0;
                while (DataGetter3.Read())
                {
                    //Order ID 
                    OrderInfo[axe, 0] = string.Empty + DataGetter3.GetInt32(0);
                    //Product ID                                   
                    OrderInfo[axe, 1] = string.Empty + DataGetter3.GetInt32(1);
                    //UnitPrice                                    
                    OrderInfo[axe, 2] = string.Empty + DataGetter3.GetDecimal(2);
                    //Quantity                                     
                    OrderInfo[axe, 3] = string.Empty + DataGetter3.GetInt16(3);
                    //Subtotal for Each
                    decimal placeholder = (decimal)DataGetter3.GetInt16(3);
                    OrderInfo[axe, 4] = string.Empty + (DataGetter3.GetDecimal(2) * placeholder);
                    axe++;
                }
                DataGetter3.Close();

                SqlDataReader DataGetter4 = null;
                SqlCommand myQuery4 = new SqlCommand("SELECT ProductID, ProductName FROM Products", Northwind);
                DataGetter4 = myQuery4.ExecuteReader();
                // ProductID, ProductName FROM Products
                axe = 0;
                while (DataGetter4.Read())
                {
                    //Product ID 
                    ProdInfo[axe, 0] = string.Empty + DataGetter4.GetInt32(0);
                    //Product Name                                
                    ProdInfo[axe, 1] = DataGetter4.GetString(1);

                    axe++;
                }
                DataGetter4.Close();
                for (int x = 0; x < axe; x++)
                {
                    Customer_Combo.Items.Add(CustInfo[x, 1]);
                }
                Check_Radio();
                Additional_Query();
            }

            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }


        public void Check_Radio()  //Checks the radio buttons for there type and enables/disables field accordingly
        {
            if (Order_Date_Range.IsChecked == true)
            {
                From_Date.IsEnabled = true;
                Till_Date.IsEnabled = true;
                Customer_Combo.IsEnabled = false;
                
                
            }
            else if (Customer_Style.IsChecked == true)
            {
                From_Date.IsEnabled = false;
                Till_Date.IsEnabled = false;
                Customer_Combo.IsEnabled = true;
            }

        }

        private void Customer_Style_Checked(object sender, RoutedEventArgs e)
        {
            Check_Radio();
        }

        private void Order_Date_Range_Checked(object sender, RoutedEventArgs e)
        {
            Check_Radio();
        }

        private void Submit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Order_Date_Range.IsChecked == true)
            {
                int FromDate = 0;
                int TillDate = 0;
                for (int x = 0; x < OrderNum.GetLength(0); x++)  //finds the minumum value of the date ranges to move to data grid. 
                {
                    if (From_Date.SelectedItem.ToString().Equals(OrderNum[x, 2]))
                    {
                        FromDate = x;
                        break;
                    }
                }
                for (int x = 0; x < OrderNum.GetLength(0); x++)  //finds the maximum value of the date ranges to move to data grid. 
                {
                    if (Till_Date.SelectedItem.ToString().Equals(OrderNum[x, 2]))
                    {
                        TillDate = x;
                    }
                }

                if (TillDate > FromDate)
                {
                    decimal Grand_Total = 0;
                    DataTable SummaryWindow = new DataTable();
                    SummaryWindow.Columns.Add("Order Number");
                    SummaryWindow.Columns.Add("Customer Name");
                    SummaryWindow.Columns.Add("Order Date");
                    SummaryWindow.Columns.Add("Subtotal");

                    for (int x = FromDate; x <= TillDate; x++) //Looks at only the dates specified
                    {
                        DataRow SummaryRow = SummaryWindow.NewRow();


                        for (int y = 0; y < OrderNum.GetLength(0); y++) //finds the Customer name
                            if (OrderNum[x, 1].Equals(CustInfo[y, 0]))
                            {
                               
                                String.Format("{0:C2}", OrderNum[x, 3].ToString());
                                SummaryRow["Order Number"] = OrderNum[x, 0];
                                SummaryRow["Customer Name"] = CustInfo[y, 1];
                                SummaryRow["Order Date"] = OrderNum[x, 2];
                                SummaryRow["Subtotal"] = OrderNum[x, 3];
                                SummaryWindow.Rows.Add(SummaryRow);
                                Grand_Total = Grand_Total + decimal.Parse(OrderNum[x, 3]);
                            }

                    }
                    Grand_Total_Box.Text = String.Empty + Grand_Total;
                    Summary_Grid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = SummaryWindow });
                }
                else
                {
                    MessageBox.Show("Warning! From Date should be earlier than To Date!");
                }
            }
               
            if (Customer_Style.IsChecked == true)
            {
                decimal Grand_Total = 0;
                DataTable SummaryWindow = new DataTable();
                SummaryWindow.Columns.Add("Order Number");
                SummaryWindow.Columns.Add("Customer Name");
                SummaryWindow.Columns.Add("Order Date");
                SummaryWindow.Columns.Add("Subtotal");

                for (int x = 0; x < CustInfo.GetLength(0); x++) 
                {
                    

                    if (Customer_Combo.SelectedItem.Equals(CustInfo[x, 1]))
                    {
                        for (int y = 0; y < OrderNum.GetLength(0); y++) //finds the Customer name
                            if (CustInfo[x, 0].Equals(OrderNum[y, 1]))
                            {
                                DataRow SummaryRow = SummaryWindow.NewRow();
                                SummaryRow["Order Number"] = OrderNum[y, 0];
                                SummaryRow["Customer Name"] = CustInfo[x, 1];
                                SummaryRow["Order Date"] = OrderNum[y, 2];
                                SummaryRow["Subtotal"] = OrderNum[y, 3];
                                SummaryWindow.Rows.Add(SummaryRow);
                                Grand_Total = Grand_Total + Decimal.Parse(OrderNum[x, 3]);
                            }
                    }
                }
                Grand_Total_Box.Text = String.Empty + Grand_Total;
                Summary_Grid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = SummaryWindow });
            }
        }

        public void Additional_Query()
        {
            try
            {

                int axe = 0;
                SqlDataReader DataGetter = null;
                SqlConnection Northwind = new SqlConnection("Server =Localhost;" + "Trusted_Connection = true;" + "Database =northwind;");
                Northwind.Open();
                SqlCommand myQuery = new SqlCommand("SELECT OrderID, Subtotal FROM [northwind].[dbo].[Order Subtotals]", Northwind);
                DataGetter = myQuery.ExecuteReader();


                while (DataGetter.Read())
                {
                    //Order Subtotal

                    OrderNum[axe, 3] = string.Empty + DataGetter.GetDecimal(1);


                    axe++;
                }
            }
            catch (SqlException a)
            {
                MessageBox.Show(a.ToString());
            }
            }
    }
}

