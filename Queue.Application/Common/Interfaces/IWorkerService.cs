using Queue.Application.RequestModels.WorkerRequestModels;
using Queue.Application.ResponseModels.WorkerResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IWorkerService : IBaseService<Worker, WorkerResponseModel, WorkerRequestModel>
    {
    }
}
