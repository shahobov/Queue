using Microsoft.EntityFrameworkCore;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Domain.Abstract;
using Queue.Infrastructure.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queue.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbSet<TEntity> _dBset;
        private readonly EFContext _conrext;
        
        public Repository( EFContext eFContext)
        {
            _conrext = eFContext;
            _dBset = _conrext.Set<TEntity>();
           
        }
        public void Add(TEntity entity)
        {
            _dBset.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            
                _dBset.Remove(entity);
        }

        public TEntity GetById(ulong id)
        {
            return _dBset.Find(id);
        }
        public IQueryable<TEntity> GetAll()
        {
            return _dBset.Where( o => o.Id>0);
        }
        public void Update(TEntity entity, ulong id)
        {
            _dBset.Update(entity);
        }

        public int SaveChanges() => _conrext.SaveChanges();

       
    }
}
