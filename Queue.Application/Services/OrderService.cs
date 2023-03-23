using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Domain.Model;
using System;

namespace Queue.Application.Services
{
    public class OrderService: BaseService<Order, OrderResponsModel, CreateOrderRequestModel>,IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override OrderResponsModel Create(CreateOrderRequestModel request)
        {
            if(request == null) throw new ArgumentNullException();

            var entity = mapper.Map<OrderRequestModel, Order>(request);
            repository.Add(entity);
            repository.SaveChanges();
            return mapper.Map<Order, OrderResponsModel>(entity);
        }
        
        public override OrderResponsModel Get(ulong id)
        {
            return mapper.Map<Order, OrderResponsModel>(repository.GetById(id));
        }

        public override OrderResponsModel GetAll(Order entity)
        {
            return mapper.Map<Order, OrderResponsModel>(repository.GetAll(entity));
        }
        public override OrderResponsModel Update(CreateOrderRequestModel entity, ulong id)
        {
            if (entity == null) throw new ArgumentNullException(nameof(Order));
            return base.Update(entity, id);
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
