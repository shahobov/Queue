using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface IBaseService<TEntity> where TEntity: EntityBase
    {
        TEntity Get(ulong id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity, ulong id);
        TEntity Delete(ulong id);
    }
}
