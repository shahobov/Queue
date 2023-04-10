using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.Exceptions;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.OrderRequestModels;
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
        private readonly IRepository<Client> clientRepository;
        private readonly IMapper mapper;

        public ClientService(IRepository<Client> _repository, IMapper mapper) 
        {
            this.clientRepository = _repository;
            this.mapper = mapper;
        }

        public bool Validate(ClientRequestModel clientRequestModel)
        {
            var isExitsClient = clientRepository.GetById(clientRequestModel.Id);
            if (isExitsClient == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Client));
            return true;

        }

        public override ClientResponseModel Create(ClientRequestModel request)
        {
            Validate(request);
            var creatClientRequest = request as CreateClientRequestModel;
            var entity = mapper.Map<CreateClientRequestModel, Client>(creatClientRequest);
            clientRepository.Add(entity);
            clientRepository.SaveChanges();
            return mapper.Map<Client, CreateClientResponeModel>(entity);
        }

        public override GetClientResponseModel Get(ulong id)
        {      
                return mapper.Map<Client, GetClientResponseModel>(clientRepository.GetById(id));
        }

        public override IEnumerable<GetClientResponseModel> GetAll()
        {
            var clients = clientRepository.GetAll();
            
            return mapper.Map<IEnumerable<GetClientResponseModel>>(clients);
        }

        public override ClientResponseModel Update(ClientRequestModel request, ulong id)
        {
            Validate(request);

            var client = clientRepository.GetById(id);
            var updateClientRequest = request as UpdateClientRequestModel;
            mapper.Map<UpdateClientRequestModel, Client>(updateClientRequest);
            clientRepository.Update(client,id);
            clientRepository.SaveChanges();
            return mapper.Map<Client, UpdateClientResponseModel>(client);
        }

        public override bool Delete(ulong id)
        {
            var result = clientRepository.GetById(id);
            if (result != null)
            {
                clientRepository.Delete(result);
                clientRepository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
