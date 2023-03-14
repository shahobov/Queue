using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class QueueForService : EntityBase
    {
        public Service Service { get; set; }
        public Client Client { get; set; }
        public Worker Worker { get; set; }
        public DateTime DateTimeOfQueue { get; set; }

    }
}
