using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public int Id { get; set; }

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
        private int customerId;
        public int CustomerId
        {
            get => customerId;
            set
            {
                customerId = value;
                OnPropertyChanged(nameof(CustomerId));
            }
        }
        private int amount;
        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private int rate;
        public int Rate
        {
            get => rate;
            set
            {
                rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }
        private string branch;
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
