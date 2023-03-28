using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Domain.Abstract;

namespace Queue.Domain.Model
{
    public class Worker : Person
    {
        public Job Job { get; set; }
        public Schedule Schedule { get; set; }
        public ulong ScheduleId { get; set; }

        public bool IsActived { get; set; }
    }
}
