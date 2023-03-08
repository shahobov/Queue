using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class Queues : EntityBase
    {
        public Queue Entity { get; set; }
        public Client Client { get; set; }
        public DateTime QueueDateTime { get; set; }
        public int NumberOfQueue { get; set; }
    }
}
