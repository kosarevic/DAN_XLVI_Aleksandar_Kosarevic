using System;
using System.Collections.Generic;
using System.Configuration;
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
using Zadatak_1.Model;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "WPFadmin" && txtPassword.Password == "WPFadmin")
            {
                AddManagerWindow window = new AddManagerWindow();
                window.Show();
                this.Close();
                return;
            }

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            try
            {
                //User is extracted from the database matching inserted paramaters Username and Password.
                SqlCommand query = new SqlCommand("SELECT * FROM tblManager WHERE Username=@Username AND Password=@Password", sqlCon);
                query.CommandType = CommandType.Text;
                query.Parameters.AddWithValue("@Username", txtUsername.Text);
                query.Parameters.AddWithValue("@Password", txtPassword.Password);
                sqlCon.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                Manager m = new Manager();

                foreach (DataRow row in dataTable.Rows)
                {
                    m = new Manager
                    {
                        AccessLevel = row[12].ToString(),
                    };
                }

                if (m.AccessLevel == "Modify")
                {
                    ModifyManagerWindow window = new ModifyManagerWindow();
                    window.Show();
                    this.Close();
                }
                else if (m.AccessLevel == "Read-Only")
                {
                    ReadOnlyManagerWindow window = new ReadOnlyManagerWindow();
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
