using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Application.RequestModels.WorkerRequestModel;
using Queue.Application.ResponseModels.WorkerResponseModel;

namespace Queue.Application.Common.Interfaces
{
    public interface IWorkerService : IBaseService<Worker, WorkerResponseModel, WorkerRequestModel>
    {

    }
}
