using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.QueueForServiceResponsModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IQueueForServiceService : IBaseService<QueueForService, QueueForServiceResponsModel, QueueForServiceRequestModel>
    {
    }
}
