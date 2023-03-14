using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IRepository<Client> repository;

        public ClientService(IRepository<Client> repository)
        {
            this.repository = repository;
        }
        
        public override Client Get(ulong id)
        {
            if(id == 1)
            {
                return new Client() 
                {
                    FirstName = "Samadjon"
                   
                };
            }
            return new Client() 
            { 
                FirstName ="Client not found"
            };
        }
        public override Client Create(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(Client));
            };
            repository.Add(entity);
            repository.SaveChanges();
            return entity;
        }
    }
}
