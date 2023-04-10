using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.Exceptions;
using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Application.ResponseModels.OrderResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Queue.Application.Services
{
    public class OrderService: BaseService<Order, OrderResponseModel, OrderRequestModel>,IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Worker> workerRepository;
        private readonly IRepository<Service> serviceRepository;
        private readonly IRepository<Client> clientRepository;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> _orderRepository, IMapper mapper, IRepository<Worker> workerRepository, IRepository<Service> serviceRepository, IRepository<Client> clientRepository)
        {
            orderRepository = _orderRepository;
            this.mapper = mapper;
            this.workerRepository = workerRepository;
            this.serviceRepository = serviceRepository;
            this.clientRepository = clientRepository;
        }

        public bool Validate(OrderRequestModel orderRequestModel)
        {   
            var isExitsClient = clientRepository.GetById(orderRequestModel.ClientId);
            if (isExitsClient == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound,nameof(Client));

            var isExitstWorker = workerRepository.GetById(orderRequestModel.WorkerId);
            if (isExitstWorker == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Worker));

            var isExitsService = serviceRepository.GetById(orderRequestModel.ServiceId);
            if (isExitsService == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Service));

            var isExitsOrder = orderRepository
                            .GetAll()
                            .Where(o => o.WorkerId == orderRequestModel.WorkerId &&
                                  o.OrderDate == orderRequestModel.OrderDate &&
                                  (orderRequestModel.StartServiceTimes > o.StartServiceTimes &&
                                  orderRequestModel.StartServiceTimes < o.EndExequteTimeService) &&
                                  o.QueueStatus == 1)
                            .Count();
            if (isExitsOrder == 1)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));
            return true;
        }

        public override OrderResponseModel Create(OrderRequestModel orders)
        {
           Validate(orders);
           var createOrderRequest = orders as CreateOrderRequestModel;
           var entity = mapper.Map<CreateOrderRequestModel, Order>(createOrderRequest);
           entity.EndExequteTimeService = orders.StartServiceTimes.AddMinutes(serviceRepository.GetById(orders.ServiceId).ExecutionTime);
           orderRepository.Add(entity);
           orderRepository.SaveChanges();
           return mapper.Map<Order, CreateOrderResponseModel>(entity);
        }

        public override OrderResponseModel Get(ulong id)
        {
            return mapper.Map<Order, GetOrderResponseModel>(orderRepository.GetById(id));
        }

        public override IEnumerable<OrderResponseModel> GetAll()
        {
            var clients = orderRepository.GetAll();

            return mapper.Map<IEnumerable<GetOrderResponseModel>>(clients);
        }

        public override OrderResponseModel Update(OrderRequestModel request, ulong id)
        {
            Validate(request);
            var order = orderRepository.GetById(id);
            var updateOrderRequest = request as UpdateOrderRequestModel;
            mapper.Map<UpdateOrderRequestModel, Client>(updateOrderRequest);
            orderRepository.Update(order, id);
            orderRepository.SaveChanges();
            return mapper.Map<Order, UpdateOrderResponseModel>(order);
        }

        public override bool Delete(ulong id)
        {
            var result = orderRepository.GetById(id);
            if (result != null)
            {
                orderRepository.Delete(result);
                orderRepository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
