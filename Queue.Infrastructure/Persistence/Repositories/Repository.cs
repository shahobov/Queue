using Microsoft.EntityFrameworkCore;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Domain.Model;
using Queue.Infrastructure.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly EFContext _conrext;
        private readonly DbSet<TEntity> _dBset;
        public Repository( EFContext eFContext)
        {
            _dBset = _conrext.Set<TEntity>();
            _conrext = eFContext;
        }
        public void Add(TEntity entity)
        {
            _dBset.Add(entity);
        }

        public void Delete(TEntity entity, ulong id)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(ulong id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()=> _conrext.SaveChanges();
        
        public TEntity Update(TEntity entity, ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
