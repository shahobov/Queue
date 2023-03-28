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
        public DateTime Date { get; set; }
        public List<ScheduleDetiles> ScheduleDetiles { get; set;}
    }
}
