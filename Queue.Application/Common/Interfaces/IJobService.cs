using Queue.Application.RequestModels.JobRequestModel;
using Queue.Application.ResponseModels.JobResponseModel;
using Queue.Domain.Model;

namespace Queue.Application.Common.Interfaces;

public interface IJobService:IBaseService<Job,JobResponseModel,JobRequestModel>
{
    
}