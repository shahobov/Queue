using Queue.Application.RequestModels.WorkerSkillsRequestModel;
using Queue.Application.ResponseModels.WorkerSkillsResponseModel;
using Queue.Domain.Model;

namespace Queue.Application.Common.Interfaces;

public interface IWorkerSkillsService:IBaseService<WorkerSkills,WorkerSkillsResponseModel,WorkerSkillsRequestModel>
{
    
}