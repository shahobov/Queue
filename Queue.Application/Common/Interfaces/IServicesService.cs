using Queue.Application.RequestModels.ServiceRequestModels;
using Queue.Application.ResponseModels.ServiceResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IServicesService : IBaseService<Service, ServiceResponseModel, ServiceRequestModel>
    {
    }
}
