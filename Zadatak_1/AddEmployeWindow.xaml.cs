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
using Zadatak_1.Validation;
using Zadatak_1.ViewModel;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for AddEmployeWindow.xaml
    /// </summary>
    public partial class AddEmployeWindow : Window
    {
        ModifyManagerViewModel mmvm = new ModifyManagerViewModel();

        public AddEmployeWindow()
        {
            InitializeComponent();
            DataContext = mmvm;
            mmvm.Employe.FirstName = "";
            mmvm.Employe.LastName = "";
            mmvm.Employe.JMBG = "";
            mmvm.Employe.Email = "";
            mmvm.Employe.Position = "";
            mmvm.Employe.Username = "";
            mmvm.Employe.Password = "";
        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            if (AddEmployeValidation.Validate(mmvm.Employe))
            {
                mmvm.AddEmploye();
            }
        }
        //Button click navigates user to previous window.
        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            LoginScreen window = new LoginScreen();
            window.Show();
            this.Close();
        }
    }
}
