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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace WpfApplication1
{
    class ServerConnect
    {
       public static bool MyConnection(String userName, String password) {
            try
            {
                //SqlDataReader myReader = null;
                SqlConnection Northwind = new SqlConnection("Server =Localhost;" + "Database =NORTHWND;" + "trusted_Connection = true;" + "User ID = " + userName + ", " + "Password= " + password + ";" + "User Instance= true;");
                Northwind.Open();
                // SqlCommand myCommand = new SqlCommand("USE northwind SELECT ContactName, ContactTitle, Phone FROM Customers", Northwind);
                //myReader = myCommand.ExecuteReader();
                //+"Trusted_Connection = false;"
                MessageBox.Show("The connection was successful");
                // while (myReader.Read())
                // {
                //     MessageBox.Show(myReader["ContactName"].ToString());
                // }
                return true;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
                return false;
            }

        }
        public static int[] Find_Invoice_Data()
        {
            try
            {
                
                int axe = 0;
                SqlDataReader DataGetter = null;
                SqlConnection Northwind = new SqlConnection("Server =Localhost;" + "Trusted_Connection = true;" + "Database =NORTHWND;");
                Northwind.Open();
                SqlCommand myQuery = new SqlCommand("SELECT OrderID FROM Orders", Northwind);
                DataGetter = myQuery.ExecuteReader();
                int[] OrderNum = new int[2000];
                while (DataGetter.Read())
                {
                    OrderNum[axe] = DataGetter.GetInt32(0);
                    axe++;
                }
                return OrderNum;
            }
            catch (Exception a)
            { 
            MessageBox.Show(a.ToString());
                return null;

            }
        }
    }
}
    



