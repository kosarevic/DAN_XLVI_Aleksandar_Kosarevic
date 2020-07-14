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
using Zadatak_1.Model;

namespace Zadatak_1.ViewModel
{
    class ReadOnlyManagerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employe> Employees { get; set; }

        public ReadOnlyManagerViewModel()
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
