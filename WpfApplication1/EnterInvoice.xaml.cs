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
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication1
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class EnterInvoice : Page
   {
      DataTable dt = new DataTable();

      public EnterInvoice()
      {
         InitializeComponent();

         dt.Columns.Add("Product Name");
         dt.Columns.Add("Quantity");
         dt.Columns.Add("Unit Cost");
         dt.Columns.Add("Subtotal");
         dt.NewRow();

         invoiceGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dt });

         try // This try catch block populates the user data from the SQL server into the combo box that lets you select a user when the page first opens. 
         {
            SqlDataReader Reader = null;
            SqlConnection Northwind = new SqlConnection("Server = localhost;" + "Trusted_Connection = true;" + "Database = northwind;");
            Northwind.Open();
            SqlCommand PopulateUserIDs = new SqlCommand("SELECT CustomerID FROM Customers", Northwind);
            SqlCommand LoadInvoiceNo = new SqlCommand("SELECT MAX(OrderID) AS OrderID FROM  [Order Details]", Northwind);
            Reader = PopulateUserIDs.ExecuteReader();
            while (Reader.Read())
            {
               cmbCustomer_ID.Items.Add(Reader["CustomerID"]);
            }

            string ComboGet = string.Empty + cmbCustomer_ID.SelectedItem;
            cmbCustomer_ID.SelectedItem = ComboGet;

            Reader.Close();

            Reader = LoadInvoiceNo.ExecuteReader();
            while (Reader.Read())
            {
               string ReceiveInvoiceNo = (Reader["OrderID"].ToString());
               int ConvertInvoiceNo = Convert.ToInt32(ReceiveInvoiceNo);
               ConvertInvoiceNo = ConvertInvoiceNo + 1;
               InvoiceNumber.Text = Convert.ToString(ConvertInvoiceNo);
            }

            Northwind.Close();
         }

         catch (Exception e)
         {
            MessageBox.Show(e.ToString());
         }
      }





      #region Methods

      public static int isNumber(string value)
      {
         int num;

         bool result = Int32.TryParse(value, out num);
         if (result)
         {
            return num;
         }
         else
         {
            return -1;
         }
      }


      #endregion

      #region Events

      private void btnAddItem_Click(object sender, RoutedEventArgs e)
      {
         int testValue = isNumber(txtInventoryNumber.Text);
         if (testValue < 1 || testValue > 77)
         {
            MessageBox.Show("Please input an integer between 1 and 77 for item number.");
         }
         else
         {
            testValue = isNumber(txtQuantity.Text);
            if (testValue < 1)
            {
               MessageBox.Show("Please input a positive integer for quantity ordered.");
            }
            else
            {
               try
               {
                  SqlDataReader Reader = null;
                  SqlConnection Northwind = new SqlConnection("Server = localhost;" + "Trusted_Connection = true;" + "Database = northwind;");
                  Northwind.Open();
                  SqlCommand FillInvoiceRow = new SqlCommand("SELECT ProductName, UnitPrice FROM Products WHERE ProductID = " + txtInventoryNumber.Text, Northwind);
                  Reader = FillInvoiceRow.ExecuteReader();

                  while (Reader.Read())
                  {
                     DataRow row = dt.NewRow();
                     row["Product Name"] = Reader["ProductName"];
                     row["Quantity"] = txtQuantity.Text;
                     row["Unit Cost"] = Reader["UnitPrice"];
                     double cost = Convert.ToDouble(Reader["UnitPrice"]);
                     double quantity = Convert.ToDouble(txtQuantity.Text);
                     double subtotal = cost * quantity;
                     row["Subtotal"] = subtotal;
                     dt.Rows.Add(row);
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.ToString());
               }
            }
         }
      }

      private void Customer_ID_SelectionChanged(object sender, SelectionChangedEventArgs e) // This updates the customer name and address whenever the user changes the customer ID selection
      {
         SqlDataReader Reader = null;
         SqlConnection Northwind = new SqlConnection("Server = localhost;" + "Trusted_Connection = true;" + "Database = northwind;");
         Northwind.Open();
         SqlCommand PopulateCustomerInfo = new SqlCommand("SELECT ContactName, Address, City FROM Customers WHERE CustomerID = '" + cmbCustomer_ID.Text + "'", Northwind);
         Reader = PopulateCustomerInfo.ExecuteReader();

         while (Reader.Read())
         {
            Customer_Address.Text = (Reader["Address"].ToString()) + ", " + (Reader["City"].ToString());
            Customer_Name.Text = (Reader["ContactName"].ToString());
         }
      }

      private void btnReset_Click(object sender, RoutedEventArgs e)
      {
         for (int i = dt.Rows.Count - 1; i >= 0; i--)
         {
            dt.Rows[i].Delete();
         }
      }

      private void btnUndo_Click(object sender, RoutedEventArgs e)
      {
         if (dt.Rows.Count > 0)
         {
            int i = dt.Rows.Count - 1;
            dt.Rows[i].Delete();
         }
      }

      #endregion
   }
}
