using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public Branch Branch { get; set; }
    }
}
