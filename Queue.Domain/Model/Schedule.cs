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
        public int  WorkerId { get; set; }
        public DateTime StartOfWork { get; set; }
        public DateTime EndOfWork { get; set; }
        public int Hour { get; set; }
        public DayOfTheWeek RestDay { get; set; }
    }
}
