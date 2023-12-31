﻿using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace View.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        public int Id { get; set; }

        private string firstName;
        public string FirstName 
        { 
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string region;
        public string Region
        {
            get => region;
            set
            {
                region = value;
                OnPropertyChanged(nameof(Region));
            }
        }
        private string address;
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
    }
}
