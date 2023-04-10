using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IClientService: IBaseService<Client, ClientResponseModel, ClientRequestModel>
    {
    }
}
