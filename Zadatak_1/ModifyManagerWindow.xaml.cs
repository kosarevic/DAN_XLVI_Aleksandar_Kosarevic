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
using Zadatak_1.ViewModel;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for ModifyManagerWindow.xaml
    /// </summary>
    public partial class ModifyManagerWindow : Window
    {
        ModifyManagerViewModel mmvm = new ModifyManagerViewModel();

        public ModifyManagerWindow()
        {
            InitializeComponent();
            DataContext = mmvm;
        }
        //Button click executes AddEmployeWindow.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeWindow window = new AddEmployeWindow();
            window.Show();
            this.Close();
        }
        //Button click executes EditEmployeWindow.
        private void HyperlinkButton_Edit(object sender, RoutedEventArgs e)
        {
            EditEmployeWindow window = new EditEmployeWindow(mmvm.Employe);
            window.Show();
            this.Close();
        }
        //Button click executes DeleteEmploye method.
        private void HyperlinkButton_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                mmvm.DeleteEmploye();
            }
        }
        //Button click navigates user to previous window.
        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginScreen screen = new LoginScreen();
            screen.Show();
            this.Close();
        }
    }
}
