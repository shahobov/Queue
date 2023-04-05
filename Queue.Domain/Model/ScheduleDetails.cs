using Queue.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Domain.Model
{
    public class ScheduleDetails : EntityBase
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ulong ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
