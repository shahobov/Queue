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
    public class ClientService : BaseService<Client>, IClientService, IClientServiceRepositry
    {
        private readonly IClientService _clientService;
        private readonly IClientServiceRepositry _clientServiceRepositry;
        public override Client Get(ulong id)
        {
            if(id == 1)
            {
                return new Client() 
                { 
                    FullName ="Samadjon"
                   
                };
            }
            return new Client() 
            { 
                FullName ="Client not found"
            };
        }
        public override  Client Create(Client entity)
        {

            Client c = new Client();
            c.Login = "MyLogin";
            c.Password = "password";
            c.FullName = "Abdumajid";
            c.PhoneNumber = "1234567890";
            c.Gender = true;
            var data = _clientServiceRepositry.Add(c);
            return base.Create(entity);
        }

        public Task Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client entity, ulong id)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<Client>.Update(Client entity, ulong id)
        {
            throw new NotImplementedException();
        }

        public Client GetById(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
