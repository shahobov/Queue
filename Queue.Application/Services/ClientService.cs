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
    public class ClientService : BaseService<Client, ClientResponseModel,ClientRequestModel>, IClientService
    {
        private readonly IRepository<Client> repository;
        private readonly IMapper mapper;

        public ClientService(IRepository<Client> repository, IMapper mapper) 
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override ClientResponseModel Create(ClientRequestModel request)
        {
            if (request == null) throw new ArgumentNullException(nameof(Client));

            var creatClientRequest = request as CreateClientRequestModel;

            var entity = mapper.Map<CreateClientRequestModel, Client>(creatClientRequest);
            repository.Add(entity);
            repository.SaveChanges();
            return mapper.Map<Client, CreateClientResponeModel>(entity);
        }

        public override GetClientResponseModel Get(ulong id)
        {      
                return mapper.Map<Client, GetClientResponseModel>(repository.GetById(id));
        }

        public override IEnumerable<GetClientResponseModel> GetAll()
        {
            var clients = repository.GetAll();
            
            return mapper.Map<IEnumerable<GetClientResponseModel>>(clients);
        }
        public override ClientResponseModel Update(ClientRequestModel request, ulong id)
        {
            var client = repository.GetById(id);
            if (client == null) throw new ArgumentNullException(nameof(Client));
            var updateClientRequest = request as UpdateClientRequestModel;
            mapper.Map<UpdateClientRequestModel, Client>(updateClientRequest);
            repository.Update(client,id);
            repository.SaveChanges();
            return mapper.Map<Client, UpdateClientResponseModel>(client);

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
