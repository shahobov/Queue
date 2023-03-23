using Queue.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces.Repositories
{
    public interface  IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity, ulong id);
        TEntity GetById(ulong id);
        TEntity GetAll(TEntity entity);
        //IQueryable<TEntity> GetAll(int pageSize, int pageNumber, CancellationToken cancellation);
        int SaveChanges ();
       
    }
}
