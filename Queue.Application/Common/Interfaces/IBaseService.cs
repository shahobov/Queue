using Queue.Application.RequestModels;
using Queue.Application.ResponseModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IBaseService<TEntity, TResponseModel,TRequestModel> 
        where TEntity: EntityBase
        where TResponseModel: BaseResponseModel
        where TRequestModel : BaseRequestModel
    {
        TResponseModel Get(ulong id);
        IEnumerable<TResponseModel> GetAll();
        TResponseModel Create(TRequestModel entity);
        TResponseModel Update(TRequestModel entity, ulong id);
        bool Delete(ulong id);
    }
}
