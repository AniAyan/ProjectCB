using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public ApplicationType Type { get; set; }
        public Customer Customer { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public Branch Branch { get; set; }
    }
}
