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

        //public override ClientResponseModel Get(ulong id)
        //{
        //    if(id != 0)
        //    {
        //        return Mapper.Map<Client, ClientResponseModel>(new Client() { FirstName = "Alijon", LastName = "Alijon" });
        //    }
        //    throw new ArgumentNullException(nameof(Client));
        //}
        //public override Client Create(Client entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException(nameof(Client));
        //    };
        //    _repository.Add(entity);
        //    _repository.SaveChanges();
        //    return entity;
        //}
        //public override Client Update(Client client, ulong id)
        //{
        //    if (client != null)
        //    {
        //        ;
        //        _repository.Update(client, id);
        //        _repository.SaveChanges();
        //        return client;
        //    }
        //    throw new ArgumentNullException(nameof(Client));
        //}
        //public override bool Delete( ulong id)
        //{
        //    var result=_repository.GetById(id);
        //    if(result != null)
        //    {
        //        _repository.Delete(result);
        //        _repository.SaveChanges();
        //        return true; 
        //    }
        //    return false;

        //}

    }
}
