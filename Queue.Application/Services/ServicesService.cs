using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.RequestModels.ServiceRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.ServiceResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ServicesService : BaseService<Service,ServiceResponseModel,ServiceRequestModel>, IServicesService
    {
        private IRepository<Service> repository;
        private IMapper mapper;

        public ServicesService(IRepository<Service> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public override ServiceResponseModel Create(ServiceRequestModel request)
        {
            if (request == null) throw new ArgumentNullException(nameof(Service));

            var createResquestModel = request as CreateServiceRequestModel;
            var service = mapper.Map<CreateServiceRequestModel, Service>(createResquestModel);
            repository.Add(service);
            repository.SaveChanges();
            return mapper.Map<Service, CreateServiceResponseModel>(service);

        }

        public override ServiceResponseModel Update(ServiceRequestModel request, ulong id)
        {
            var service = repository.GetById(id);
            if (service == null) throw new ArgumentNullException(nameof(Service));
            var updateServiceRequest = request as UpdateServiceRequestModel;
            mapper.Map<UpdateServiceRequestModel, Service>(updateServiceRequest);
            repository.Update(service, id);
            repository.SaveChanges();
            return mapper.Map<Service, UpdateServiceResponseModel>(service);
        }

        public override GetServiceResponseModel Get(ulong id)
        {
            return mapper.Map<Service, GetServiceResponseModel>(repository.GetById(id));
        }

        public override IEnumerable<ServiceResponseModel> GetAll()
        {
            return mapper.Map<IEnumerable<GetServiceResponseModel>>(repository.GetAll());
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
