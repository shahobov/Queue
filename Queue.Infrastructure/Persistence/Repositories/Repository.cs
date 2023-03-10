using Microsoft.EntityFrameworkCore;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Domain.Model;
using Queue.Infrastructure.Persistence.Database;
using System.Threading.Tasks;

namespace   Queue.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbSet<T> _dbSet;
        private readonly EFContext _context;

        public Repository(EFContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity, ulong id)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(ulong id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T entity, ulong id)
        {
            throw new System.NotImplementedException();
        }
    }
}
