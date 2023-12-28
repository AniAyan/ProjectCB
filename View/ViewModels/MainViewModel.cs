using AutoMapper;
using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Mapping;

namespace View.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly CustomerRepository customerRepository;
        private readonly CustomerDTOViewModelMapper customerMapper;

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

        public MainViewModel(CustomerRepository customerRepository, CustomerDTOViewModelMapper customerMapper)
        {
            this.customerRepository = customerRepository;
            this.customerMapper = customerMapper;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            var customersFromCore = customerRepository.GetCustomers();
            Customers = new ObservableCollection<CustomerViewModel>(customerMapper.MapToViewModelList(customersFromCore));
        }
    }
}
