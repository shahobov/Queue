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
        private IRepository<Service> _serviceRepository;
        private IRepository<Category> categoryRepository;
        private IMapper mapper;

        public ServicesService(IRepository<Service> repository, IMapper mapper, IRepository<Category> categoryRepository)
        {
            this._serviceRepository = repository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;   
        }

        public override ServiceResponseModel Create(ServiceRequestModel request)
        {
            if (request == null) throw new ArgumentNullException(nameof(Service));

            var createResquestModel = request as CreateServiceRequestModel;
            var service = mapper.Map<CreateServiceRequestModel, Service>(createResquestModel);
            _serviceRepository.Add(service);
            _serviceRepository.SaveChanges();
            return mapper.Map<Service, CreateServiceResponseModel>(service);
        }

        public override ServiceResponseModel Update(ServiceRequestModel request, ulong id)
        {
            var service = _serviceRepository.GetById(id);
            if (service == null) throw new ArgumentNullException(nameof(Service));
            var updateServiceRequest = request as UpdateServiceRequestModel;
            mapper.Map<UpdateServiceRequestModel, Service>(updateServiceRequest);
            _serviceRepository.Update(service, id);
            _serviceRepository.SaveChanges();
            return mapper.Map<Service, UpdateServiceResponseModel>(service);
        }

        public override GetServiceResponseModel Get(ulong id)
        {
            return mapper.Map<Service, GetServiceResponseModel>(_serviceRepository.GetById(id));
        }

        public override IEnumerable<ServiceResponseModel> GetAll()
        {
            return mapper.Map<IEnumerable<GetServiceResponseModel>>(_serviceRepository.GetAll());
        }

        public override bool Delete(ulong id)
        {
            var result = _serviceRepository.GetById(id);
            if (result != null)
            {
                _serviceRepository.Delete(result);
                _serviceRepository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
