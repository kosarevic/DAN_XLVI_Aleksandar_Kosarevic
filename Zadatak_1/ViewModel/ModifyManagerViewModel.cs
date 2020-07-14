using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zadatak_1.Model;
using Zadatak_1.Validation;

namespace Zadatak_1.ViewModel
{
    class ModifyManagerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employe> Employees { get; set; }

        public ModifyManagerViewModel()
        {
            Employe = new Employe();
            FillList();
        }

        private Employe employe;

        public Employe Employe
        {
            get { return employe; }
            set
            {
                if (employe != value)
                {
                    employe = value;
                    OnPropertyChanged("Employee");
                }
            }
        }

        public void FillList()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                SqlCommand query = new SqlCommand("select * from tblEmploye", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (Employees == null)
                    Employees = new ObservableCollection<Employe>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Employe e = new Employe
                    {
                        Id = int.Parse(row[0].ToString()),
                        FirstName = row[1].ToString(),
                        LastName = row[2].ToString(),
                        DateOfBirth = DateTime.Parse(row[3].ToString()),
                        JMBG = row[4].ToString(),
                        Account = int.Parse(row[5].ToString()),
                        Email = row[6].ToString(),
                        Salary = int.Parse(row[7].ToString()),
                        Position = row[8].ToString(),
                        Username = row[9].ToString(),
                        Password = row[10].ToString()
                    };
                    Employees.Add(e);
                }
            }
        }

        public void DeleteEmploye()
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            con.Open();
            var cmd = new SqlCommand("delete from tblEmploye where EmployeID = @EmployeID;", con);
            cmd.Parameters.AddWithValue("@EmployeID", employe.Id);
            cmd.ExecuteNonQuery();
            Employees.Remove(employe);
            con.Close();
            con.Dispose();
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Delete successfull.", "Notification");
        }

        public void AddEmploye()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"insert into tblEmploye values (@FirstName, @LastName, @DOB, @JMBG, @Account, @Email, @Salary, @Position, @Username, @Password);", conn);
                cmd.Parameters.AddWithValue("@FirstName", Employe.FirstName);
                cmd.Parameters.AddWithValue("@LastName", Employe.LastName);
                cmd.Parameters.AddWithValue("@DOB", AddEmployeValidation.dateOfBirth);
                cmd.Parameters.AddWithValue("@JMBG", Employe.JMBG);
                cmd.Parameters.AddWithValue("@Account", Employe.Account);
                cmd.Parameters.AddWithValue("@Email", Employe.Email);
                cmd.Parameters.AddWithValue("@Salary", Employe.Salary);
                cmd.Parameters.AddWithValue("@Position", Employe.Position);
                cmd.Parameters.AddWithValue("@Username", Employe.Username);
                cmd.Parameters.AddWithValue("@Password", Employe.Password);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Employe successfully created.", "Notification");
            }
        }

        public void EditEmploye()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"update tblEmploye set FirstName=@FirstName, LastName=@LastName, DateOfBirth=@DOB, JMBG=@JMBG, Account=@Account, Email=@Email, Salary=@Salary, Position=@Position, Username=@Username, Password=@Password where EmployeID=@EmployeID;", conn);
                cmd.Parameters.AddWithValue("@EmployeID", Employe.Id);
                cmd.Parameters.AddWithValue("@FirstName", Employe.FirstName);
                cmd.Parameters.AddWithValue("@LastName", Employe.LastName);
                cmd.Parameters.AddWithValue("@DOB", AddEmployeValidation.dateOfBirth);
                cmd.Parameters.AddWithValue("@JMBG", Employe.JMBG);
                cmd.Parameters.AddWithValue("@Account", Employe.Account);
                cmd.Parameters.AddWithValue("@Email", Employe.Email);
                cmd.Parameters.AddWithValue("@Salary", Employe.Salary);
                cmd.Parameters.AddWithValue("@Position", Employe.Position);
                cmd.Parameters.AddWithValue("@Username", Employe.Username);
                cmd.Parameters.AddWithValue("@Password", Employe.Password);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Employe successfully edited.", "Notification");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
