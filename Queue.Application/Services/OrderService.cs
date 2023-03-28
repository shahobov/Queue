using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Application.ResponseModels.OrderResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;

namespace Queue.Application.Services
{
    public class OrderService: BaseService<Order, OrderResponsModel, OrderRequestModel>,IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override OrderResponsModel Create(OrderRequestModel orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(Order));

            var createOrderRequest = orders as CreateOrderRequestModel;
            

            var entity = mapper.Map<CreateOrderRequestModel, Order>(createOrderRequest);
            repository.Add(entity);
            repository.SaveChanges();
            return mapper.Map<Order,CreateOrderResponseModel >(entity);
        }

        public override OrderResponsModel Get(ulong id)
        {
            return mapper.Map<Order, GetOrderResponseModel>(repository.GetById(id));
        }

        public override IEnumerable<OrderResponsModel> GetAll()
        {
            var clients = repository.GetAll();

            return mapper.Map<IEnumerable<GetOrderResponseModel>>(clients);
        }

        public override OrderResponsModel Update(OrderRequestModel request, ulong id)
        {
            var order = repository.GetById(id);
            if (request == null) throw new ArgumentNullException(nameof(Order));
            var updateOrderRequest = request as UpdateOrderRequestModel;
            mapper.Map<UpdateOrderRequestModel, Client>(updateOrderRequest);
            repository.Update(order, id);
            repository.SaveChanges();
            return mapper.Map<Order, UpdateOrderResponseModel>(order);
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
