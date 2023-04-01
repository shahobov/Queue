using Queue.Application.RequestModels.ScheduleDetilesRequestModels;
using Queue.Application.ResponseModels.ScheduleDetilesResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IScheduleDetilesService : IBaseService<ScheduleDetiles, ScheduleDetailesResponseModel,ScheduleDetilesRequestModel>
    {
    }
}
