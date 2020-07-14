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
using Zadatak_1.Model;
using Zadatak_1.Validation;
using Zadatak_1.ViewModel;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for EditEmployeWindow.xaml
    /// </summary>
    public partial class EditEmployeWindow : Window
    {
        ModifyManagerViewModel mmvm = new ModifyManagerViewModel();

        public EditEmployeWindow(Employe e)
        {
            InitializeComponent();
            mmvm.Employe = e;
            DataContext = mmvm;
        }

        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            if (AddEmployeValidation.Validate(mmvm.Employe))
            {
                mmvm.EditEmploye();
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
