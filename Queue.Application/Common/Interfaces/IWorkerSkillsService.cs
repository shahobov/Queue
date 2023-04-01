using Queue.Application.RequestModels.WorkerSkillsRequestModels;
using Queue.Application.ResponseModels.WorkerSkillsResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IWorkerSkillsService : IBaseService<WorkerSkills,WorkerSkillsResponseModel,CreateWorkerSkillsRequestModel>
    {
    }
}
