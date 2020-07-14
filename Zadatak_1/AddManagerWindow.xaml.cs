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
    /// Interaction logic for AddManagerWindow.xaml
    /// </summary>
    public partial class AddManagerWindow : Window
    {
        AddManagerViewModel amvm = new AddManagerViewModel();

        public AddManagerWindow()
        {
            InitializeComponent();
            DataContext = amvm;
            amvm.Manager.FirstName = "";
            amvm.Manager.LastName = "";
            amvm.Manager.JMBG = "";
            amvm.Manager.Email = "";
            amvm.Manager.Position = "";
            amvm.Manager.Username = "";
            amvm.Manager.Password = "";
            amvm.Manager.Sector = "";
            amvm.Manager.AccessLevel = "";
        }
        //Button click executes AddManager method.
        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            //Validation for Manager properties.
            if (AddManagerValidation.Validate(amvm.Manager))
            {
                amvm.AddManager(); 
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
