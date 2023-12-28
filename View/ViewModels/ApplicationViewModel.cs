using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public int Id;

        private string type;
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public int customer;
        public int Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        public int amount;
        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public DateTime date;
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public int rate;
        public int Rate
        {
            get => rate;
            set
            {
                rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }
        public string branch;
        public string Branch
        {
            get => branch; 
            set
            {
                branch = value;
                OnPropertyChanged(nameof(Branch));
            }
        }
    }
}
