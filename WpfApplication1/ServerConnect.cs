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
        public static bool MyConnection(String userName, String password)
        {
            try
            {
               
                SqlConnection Northwind = new SqlConnection("Server =Localhost;" + "Database =northwind;" + "trusted_Connection = true;" + "User ID = " + userName + ", " + "Password= " + password + ";");
                Northwind.Open();
              
                MessageBox.Show("The connection was successful");
             
                return true;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
                return false;
            }

        }
    }
}
    



