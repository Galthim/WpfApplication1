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
using System.Windows.Shapes;

namespace WpfApplication1
{

    public partial class Retrieve_Invoice : Page
    {
        string[,] OrderNum = new string[2000, 2000];
        string[,] CustInfo = new string[2000, 2000];
        string[,] OrderInfo = new string[2155, 2155];
        string[,] ProdInfo = new string[2155, 2155];
        public Retrieve_Invoice()
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
                    ComboBox_Invoice.Items.Add(OrderNum[x, 0]);
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
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }

        }
        private void ComboBox_Invoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ComboGet = string.Empty + ComboBox_Invoice.SelectedItem;
            for (int x = 0; x < OrderNum.GetLength(0); x++)
            {
                if (ComboGet.Equals(OrderNum[x, 0]))
                {
                    Order_date.Text = OrderNum[x, 2];
                    for (int i = 0; i < CustInfo.GetLength(0); i++)
                    {
                        if (OrderNum[x, 1].Equals(CustInfo[i, 0]))
                        {
                            Customer_Name.Text = CustInfo[i, 1];
                            Customer_Address_Street.Text = CustInfo[i, 2] + " " + CustInfo[i, 3];

                        }
                    }



                    for (int f = 0; f < OrderInfo.GetLength(0); f++)
                    {
                        if (ComboGet.Equals(OrderInfo[f, 0]))
                        {
                            //builds the data table once the Invoice number was found
                            DataTable ProductWindow = new DataTable();
                            ProductWindow.Columns.Add("Product ID");
                            ProductWindow.Columns.Add("Product Name");
                            ProductWindow.Columns.Add("Unit Price");
                            ProductWindow.Columns.Add("Quantity");
                            ProductWindow.Columns.Add("Subtotal");




                            for (int p = 0; p < OrderInfo.GetLength(1); p++)
                            {
                                DataRow ProductRow = ProductWindow.NewRow();
                                if (ComboGet.Equals(OrderInfo[p, 0]))
                                {
                                    for (int a = 0; a <= 77; a++)
                                    {
                                        if (OrderInfo[p, 1].Equals(ProdInfo[a, 0]))
                                        {
                                            //adds only rows that are connected to Invoice number
                                            ProductRow["Product ID"] = OrderInfo[p, 1];
                                            ProductRow["Product Name"] = ProdInfo[a, 1];
                                            ProductRow["Unit Price"] = OrderInfo[p, 2];
                                            ProductRow["Quantity"] = OrderInfo[p, 3];
                                            ProductRow["Subtotal"] = OrderInfo[p, 4];
                                            ProductWindow.Rows.Add(ProductRow);
                                        }
                                    }
                                }
                            }
                            Products.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ProductWindow });
                        }
                    }
                }
            }
        } }   
} 
