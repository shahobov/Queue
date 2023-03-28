using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.WorkerResponseModels
{
    public class WorkerResponseModel : BaseResponseModel
    {
        public ulong JobId { get; set; }
        public ulong ScheduleId { get; set; }
    }
}
