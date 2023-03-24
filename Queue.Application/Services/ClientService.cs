using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ClientService : BaseService<Client, ClientResponseModel,CreateClientRequestModel>, IClientService
    {
        private readonly IRepository<Client> repository;
        private readonly IMapper mapper;

        public ClientService(IRepository<Client> repository, IMapper mapper) 
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override ClientResponseModel Create(CreateClientRequestModel request)
        {
            if (request == null) throw new ArgumentNullException(nameof(Client));

            var entity = mapper.Map<ClientRequestModel, Client>(request);
            repository.Add(entity);
            repository.SaveChanges();
            return mapper.Map<Client, ClientResponseModel>(entity);
        }
/* System.InvalidOperationException: No suitable constructor was found for
 entity type 'Client'. The following constructors had parameters 
 that could not be bound to properties of the entity type: cannot 
 bind 'connectionString', 'connectionOptions' in 'Client(object connectionString,
  object connectionOptions)'.*/
        public override ClientResponseModel Get(ulong id)
        {      
                return mapper.Map<Client, ClientResponseModel>(repository.GetById(id));
        }
        public override ClientResponseModel GetAll(Client entity)
        {
            return mapper.Map<Client, ClientResponseModel>(repository.GetAll(entity));
        }
        public override ClientResponseModel Update(CreateClientRequestModel request, ulong id)
        {
            if (request == null) throw new ArgumentNullException(nameof(Client));
            var entity = mapper.Map<ClientRequestModel, Client>(request);
            repository.Add(entity);
            repository.SaveChanges();
            return mapper.Map<Client, ClientResponseModel>(entity);

        }
        public override bool Delete(ulong id)
        {
            var result = repository.GetById(id);
            if (result != null)
            {
                repository.Delete(result);
                repository.SaveChanges();
                return true;
            }
            return false;
        }
        
      

    }
}
