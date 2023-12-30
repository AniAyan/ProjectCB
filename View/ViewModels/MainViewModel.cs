using AutoMapper;
using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Mapping;

namespace View.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly CustomerRepository customerRepository;
        private readonly ApplicationRepository applicationRepository;
        private readonly CustomerDTOViewModelMapper customerMapper;
        private readonly ApplicationDTOViewModelMapper applicationMapper;
        private readonly BranchUpdateViewModel branchUpdateViewModel;
        
        private ObservableCollection<CustomerViewModel> customers;
        public ObservableCollection<CustomerViewModel> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public MainViewModel(CustomerRepository customerRepository, ApplicationRepository applicationRepository, 
                             CustomerDTOViewModelMapper customerMapper, ApplicationDTOViewModelMapper applicationMapper,
                             BranchUpdateViewModel branchUpdateViewModel)
        {
            this.customerRepository = customerRepository;
            this.applicationRepository = applicationRepository;
            this.customerMapper = customerMapper;
            this.applicationMapper = applicationMapper;
            this.branchUpdateViewModel = branchUpdateViewModel;
            LoadCustomers();
        }

        private ObservableCollection<ApplicationViewModel> selectedCustomerApplications;
        public ObservableCollection<ApplicationViewModel> SelectedCustomerApplications
        {
            get { return selectedCustomerApplications; }
            set
            {
                if (selectedCustomerApplications != value)
                {
                    selectedCustomerApplications = value;
                    OnPropertyChanged(nameof(SelectedCustomerApplications));
                }
            }
        }
        private CustomerViewModel selectedCustomer { get; set; }
        private void LoadCustomers()
        {
            var customersFromCore = customerRepository.GetCustomers();
            Customers = new ObservableCollection<CustomerViewModel>(customerMapper.MapToViewModelList(customersFromCore));
        }

        public void UpdateCustomerApplications(CustomerViewModel selectedCustomer)
        {
            this.selectedCustomer = selectedCustomer;
            var applicationsFromCore = applicationRepository.GetApplicationsByCustomerId(selectedCustomer.Id);
            SelectedCustomerApplications = new ObservableCollection<ApplicationViewModel>(applicationMapper.MapToViewModelList(applicationsFromCore));
        }

        public void OpenBranchUpdateWindow(ApplicationViewModel selectedApplication)
        {
            BranchUpdateWindow updateWindow = new BranchUpdateWindow(branchUpdateViewModel, selectedApplication);
            updateWindow.ShowDialog();
            UpdateCustomerApplications(selectedCustomer);
        }
    }
}
