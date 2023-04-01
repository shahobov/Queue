using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.ScheduleResponseModels
{
    public class CreateScheduleResponseModel : ScheduleResponseModel
    {
        public DateTime Date { get; set; }
        public List<ScheduleDetiles> ScheduleDetiles { get; set; }
    }
}
