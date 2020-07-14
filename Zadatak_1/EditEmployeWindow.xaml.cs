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
        //Static varibale added for detecting changes to JMBG regarding later validation.
        public static string TempJmbg;

        public EditEmployeWindow(Employe e)
        {
            InitializeComponent();
            mmvm.Employe = e;
            DataContext = mmvm;
            TempJmbg = e.JMBG;
        }
        //Button click executes EditEmploye method.
        private void Btn_Confirm(object sender, RoutedEventArgs e)
        {
            if (EditEmployeValidation.Validate(mmvm.Employe))
            {
                mmvm.EditEmploye();
                ModifyManagerWindow window = new ModifyManagerWindow();
                window.Show();
                this.Close();
            }
        }
        //Button click navigates user to previous window.
        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            ModifyManagerWindow window = new ModifyManagerWindow();
            window.Show();
            this.Close();
        }
    }
}
