using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.RequestModels.ServiceRequestModels;
using Queue.Application.ResponseModels.ServiceResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ServicesService : BaseService<Service,ServiceResponseModel,CreateServiceRequestModel>, IServicesService
    {
        private IRepository<Service> repository;
        private IMapper mapper;

        public ServicesService(IRepository<Service> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }







        //public override ServiceResponseModel Create(CreateServiceRequestModel entity)
        //{
        //    if(entity == null) throw new ArgumentNullException(nameof(Service));

        //    var service = mapper.Map<ServiceRequestModel,Service>(entity);
        //    repository.Add(service);
        //    repository.SaveChanges();
        //    return mapper.Map<Service, ServiceResponseModel>(service);

        //}

        //public override ServiceResponseModel Update(CreateServiceRequestModel entity, ulong id)
        //{
        //    return base.Update(entity, id);
        //}

        //public override ServiceResponseModel Get(ulong id)
        //{
        //    return mapper.Map<Service, ServiceResponseModel>(repository.GetById(id));
        //}

        //public override ServiceResponseModel GetAll(Service entity)
        //{
        //    return mapper.Map<Service, ServiceResponseModel>(repository.GetAll(entity));
        //}

        //public override bool Delete(ulong id)
        //{
        //    var result = repository.GetById(id);
        //    if (result != null)
        //    {
        //        repository.Delete(result);
        //        repository.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
    }
}
