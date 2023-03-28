using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels;
using Queue.Application.ResponseModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public abstract class BaseService<TEntity, TResponseModel, TRequestModel> : IBaseService<TEntity, TResponseModel, TRequestModel>
        where TEntity : EntityBase
        where TResponseModel : BaseResponseModel
        where TRequestModel : BaseRequestModel
    {
        public virtual TResponseModel Create(TRequestModel entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public virtual TResponseModel Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual TResponseModel Update(TRequestModel entity, ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
