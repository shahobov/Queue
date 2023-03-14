using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces.Repositories
{
    public interface  IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        void Delete(TEntity entity, ulong id);
        TEntity Update(TEntity entity, ulong id);
        TEntity GetById(ulong id);
        int SaveChanges ();
       
    }
}
