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
using System.Windows.Navigation;
using System.Windows.Shapes;
using View.ViewModels;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Customer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainViewModel mainViewModel = DataContext as MainViewModel;
            CustomerViewModel selectedCustomer = customerGrid.SelectedItem as CustomerViewModel;

            if (mainViewModel != null && selectedCustomer != null)
            {
                mainViewModel.UpdateCustomerApplications(selectedCustomer);
            }
        }
        private void BranchCell_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainViewModel mainViewModel = DataContext as MainViewModel;
            ApplicationViewModel selectedApplication = applicationGrid.SelectedItem as ApplicationViewModel;

            if (mainViewModel != null && selectedApplication != null)
            {
                mainViewModel.OpenBranchUpdateWindow(selectedApplication);
            }
        }
    }
}
