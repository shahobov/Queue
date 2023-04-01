using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IJobService : IBaseService<Job,JobResponseModel,JobRequestModel>
    {
    }
}
