using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly CustomerRepository customerRepository;
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

        public MainViewModel(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        /*private List<CustomerViewModel> GetCustomersFromCore()
        {
            return customerRepository.GetCustomers();
        }*/
    }
}
