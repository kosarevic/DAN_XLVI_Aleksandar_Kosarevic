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
    /// Interaction logic for ReadOnlyManagerWindow.xaml
    /// </summary>
    public partial class ReadOnlyManagerWindow : Window
    {
        ReadOnlyManagerViewModel romvm = new ReadOnlyManagerViewModel();

        public ReadOnlyManagerWindow()
        {
            InitializeComponent();
            DataContext = romvm;
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginScreen screen = new LoginScreen();
            screen.Show();
            this.Close();
        }
    }
}
