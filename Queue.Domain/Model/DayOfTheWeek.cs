using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Domain.Abstract;

namespace Queue.Domain.Model
{
    public class DayOfTheWeek : EntityBase
    {
        public string NameOfTheWeek { get; set; }
    }
}
