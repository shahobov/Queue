using Microsoft.EntityFrameworkCore;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.DBContext;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services.Repositories
{
    internal class ClientServiceRepository : IBaseRepository<Client>
    {
        private readonly AplicationContext _context;
        public ClientServiceRepository(AplicationContext context)
        {
            _context = context;
        }
        public async Task Add(Client entity)
        {
           await _context.AddAsync(entity);
        }

        public void Delete(Client entity, ulong id)
        {
            if(id == 0)
            {
                var oldData =  _context.Set<Client>().FirstOrDefaultAsync(o=>o.Id==id);
                if(oldData!=null)
                {
                    _context.Set<Client>().RemoveRange((IEnumerable<Client>)oldData);
                   
                }
               
            }
        }

        public Client GetById(ulong id)
        {
            return _context.Set<Client>().FirstOrDefault(o => o.Id == id);
        }

        public void Update(Client entity, ulong id)
        {
           if(id==0)
            {
                var oldData = _context.Set<Client>().FirstOrDefaultAsync(o => o.Id==id);
                if(oldData!=null)
                {
                    entity.Id = id;
                     _context.Set<Client>().Update(entity);
                }
            }
        }
    }
}
