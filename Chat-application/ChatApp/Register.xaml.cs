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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        public void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS ; Database = LRDATABASE ; Integrated Security = True");
            con.Open();
            string add_data = "INSERT INTO [dbo].[user] VALUES(@username, @password)";
            SqlCommand cmd = new SqlCommand(add_data, con);

            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@password", password.Password);  
            cmd.ExecuteNonQuery();
            con.Close();
            username.Text = "";
            password.Password = "";

            Login window2 = new Login();
            this.Close();
            window2.Show();
        }
    }
}
