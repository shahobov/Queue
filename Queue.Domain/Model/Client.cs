using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }
    }
}
