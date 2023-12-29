﻿using AutoMapper;
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
        public MainViewModel(CustomerRepository customerRepository, ApplicationRepository applicationRepository, CustomerDTOViewModelMapper customerMapper, ApplicationDTOViewModelMapper applicationMapper)
        {
            this.customerRepository = customerRepository;
            this.applicationRepository = applicationRepository;
            this.customerMapper = customerMapper;
            this.applicationMapper = applicationMapper;
            LoadCustomers();
        }

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
        public ObservableCollection<ApplicationViewModel> selectedCustomerApplications;
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
        private void LoadCustomers()
        {
            var customersFromCore = customerRepository.GetCustomers();
            Customers = new ObservableCollection<CustomerViewModel>(customerMapper.MapToViewModelList(customersFromCore));
        }

        public void UpdateCustomerApplications(CustomerViewModel selectedCustomer)
        {
            var applicationsFromCore = applicationRepository.GetApplicationsByCustomerId(selectedCustomer.Id);
            SelectedCustomerApplications = new ObservableCollection<ApplicationViewModel>(applicationMapper.MapToViewModelList(applicationsFromCore));
        }

    }
}
