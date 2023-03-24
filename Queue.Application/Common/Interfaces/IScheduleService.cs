using Queue.Application.RequestModels.ScheduleRequestModel;
using Queue.Application.ResponseModels.ScheduleResponseModel;
using Queue.Domain.Model;

namespace Queue.Application.Common.Interfaces;

public interface IScheduleService:IBaseService<Schedule,ScheduleResponseModel,ScheduleRequestModel>
{
    
}