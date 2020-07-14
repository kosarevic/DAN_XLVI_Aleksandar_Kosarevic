using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zadatak_1.Model;
using Zadatak_1.Validation;

namespace Zadatak_1.ViewModel
{
    /// <summary>
    /// Class responsible for creating new Manager, depending on inserted values.
    /// </summary>
    class AddManagerViewModel : INotifyPropertyChanged
    {

        public AddManagerViewModel()
        {
            Manager = new Manager();
        }

        private Manager manager;

        public Manager Manager
        {
            get { return manager; }
            set
            {
                if (manager != value)
                {
                    manager = value;
                    OnPropertyChanged("Manager");
                }
            }
        }
        //Sectors are pre-determined as list of possible choices.
        private List<string> sectors;

        public List<string> Sectors
        {
            get { return new List<string> { "HR", "Finance", "R&D" }; }
            set { sectors = value; }
        }
        //Access levels are pre-determined as list of possible choices.
        private List<string> accessLevels;

        public List<string> AccessLevels
        {
            get { return new List<string> { "Modify", "Read-Only" }; }
            set { accessLevels = value; }
        }
        /// <summary>
        /// Method responsible for adding new Manager into database.
        /// </summary>
        public void AddManager()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                var cmd = new SqlCommand(@"insert into tblManager values (@FirstName, @LastName, @DOB, @JMBG, @Account, @Email, @Salary, @Position, @Username, @Password, @Sector, @AccLvl);", conn);
                cmd.Parameters.AddWithValue("@FirstName", Manager.FirstName);
                cmd.Parameters.AddWithValue("@LastName", Manager.LastName);
                cmd.Parameters.AddWithValue("@DOB", AddManagerValidation.dateOfBirth);
                cmd.Parameters.AddWithValue("@JMBG", Manager.JMBG);
                cmd.Parameters.AddWithValue("@Account", Manager.Account);
                cmd.Parameters.AddWithValue("@Email", Manager.Email);
                cmd.Parameters.AddWithValue("@Salary", Manager.Salary);
                cmd.Parameters.AddWithValue("@Position", Manager.Position);
                cmd.Parameters.AddWithValue("@Username", Manager.Username);
                cmd.Parameters.AddWithValue("@Password", Manager.Password);
                cmd.Parameters.AddWithValue("@Sector", Manager.Sector);
                cmd.Parameters.AddWithValue("@AccLvl", Manager.AccessLevel);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Manager Successfully created.", "Notification");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
