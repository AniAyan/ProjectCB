using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.ViewModels;

namespace View.Infrastructure
{
    class ViewModelLocator
    {
        public MainViewModel Main => new MainViewModel();
    }
}
