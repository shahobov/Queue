using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.RequestModels.ScheduleDetilesRequestModels
{
    public abstract class ScheduleDetilesRequestModel : BaseRequestModel
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ulong ScheduleId { get; set; }
    }
}
