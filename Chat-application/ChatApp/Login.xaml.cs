using ChatApp;
using ChatClient.MVVM.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {   
        public static string BejelentkezettUser { get; set; }
        public string result { get; set; }
        public Login()
        {
            InitializeComponent();

            MouseDown += Border_MouseDown;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=LRDATABASE;Integrated Security=True");

            string add_data = "SELECT * FROM [dbo].[user] where username = @username and password = @password";
            SqlCommand cmd = new SqlCommand(add_data, con);

            cmd.Parameters.AddWithValue("@username", username.Text);
            //my:
            BejelentkezettUser = username.Text;
            cmd.Parameters.AddWithValue("@password", password.Password);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                result = (string)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (result != null)
            {
                MainWindow window2 = new MainWindow();
                window2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password or Username is not correct");
            }
        }

        private void RegisterButton_Click(Object sender, RoutedEventArgs e)
        {
            Register window3 = new Register();
            window3.Show();
            this.Close();
        }
    }
}
