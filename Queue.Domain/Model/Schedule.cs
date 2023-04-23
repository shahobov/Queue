using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Domain.Abstract;

namespace Queue.Domain.Model
{
    public class Schedule : EntityBase
    {
        public Worker Worker { get; set; }
        public ulong WorkerId { get; set; }
        public int Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBusy { get; set; }
        
    }
}
