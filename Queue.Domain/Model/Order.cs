using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Domain.Abstract;

namespace Queue.Domain.Model
{
    public class Order : EntityBase
    {
        public Service Service { get; set; }
        public ulong ServiceId { get; set; }
        public ulong ClientId { get; set; } 
        public Client Client { get; set; }
        public ulong WorkerId { get; set; }
        public Worker Worker { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan StartServiceTimes { get; set; }
        public TimeSpan EndExequteTImeService { get; set; }
        public int QueueStatus { get; set; }
    }
}
