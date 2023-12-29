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
using View.ViewModels;

namespace View
{
    /// <summary>
    /// Interaction logic for BranchUpdateWindow.xaml
    /// </summary>
    public partial class BranchUpdateWindow : Window
    {
        private readonly BranchUpdateViewModel branchUpdateViewModel;
        public BranchUpdateWindow(BranchUpdateViewModel branchUpdateViewModel, ApplicationViewModel selectedApplication)
        {
            InitializeComponent();
            this.branchUpdateViewModel = branchUpdateViewModel;
            DataContext = this.branchUpdateViewModel;
            this.branchUpdateViewModel.SetSelectedApplication(selectedApplication);
        }
    }
}
