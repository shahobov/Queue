using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces.Repositories
{
    public interface  IBaseRepository<TEntity> where TEntity : EntityBase
    {
        Task Add(TEntity entity);
        void Delete(TEntity entity, ulong id);
        void Update(TEntity entity, ulong id);
        TEntity GetById(ulong id);
    }
}
