using Queue.Application.RequestModels.ScheduleResquestModels;
using Queue.Application.ResponseModels.ScheduleResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IScheduleService : IBaseService<Schedule, ScheduleResponseModel,ScheduleResquestModel>
    {
    }
}
