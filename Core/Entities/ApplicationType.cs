﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ApplicationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
