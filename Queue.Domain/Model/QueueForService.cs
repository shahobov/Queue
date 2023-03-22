using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Domain.Abstract;

namespace Queue.Domain.Model
{
    public class QueueForService : EntityBase
    {
        public ulong ServiceId { get; set; }
        public Service Service { get; set; }
        public ulong ClientId { get; set; } 
        public Client Client { get; set; }
        public ulong WorkerId { get; set; }
        public Worker Worker { get; set; }
        public ulong PositionQueueId { get; set; }
        public int QueueStatus { get; set; }
    }
}
