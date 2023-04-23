using Queue.Application.RequestModels.OrderDetilsRequestModels;
using Queue.Application.ResponseModels.OrderDetilsResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IOrderDetilsService : IBaseService<OrderDetils,OrderDetilsResponseModel,OrderDetilsRequestModel>
    {
    }
}
