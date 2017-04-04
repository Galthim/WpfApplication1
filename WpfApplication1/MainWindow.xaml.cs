using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            Username_TextBox.Text = "";
            Password_TextBox.Clear(); 
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            //trial run to pass connection information to server

            if (WpfApplication1.ServerConnect.MyConnection(Username_TextBox.Text, Password_TextBox.Text) == true)
            {
                MainMenu Connection_Accepted = new MainMenu();
                Connection_Accepted.Show();
            }; 
            
            
        }
    }
}
