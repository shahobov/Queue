using Queue.Application.Common.Interfaces.Repositories;
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
        public void Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client entity, ulong id)
        {
            throw new NotImplementedException();
        }

        public Client GetById(ulong id)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity, ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
