using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.Exceptions;
using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Queue.Application.Services
{
    public class OrderService: BaseService<Order, OrderResponseModel, OrderRequestModel>,IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Worker> _workerRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<OrderDetils> _orderDetilsRepository;
        private readonly IMapper mapper;


        public OrderService(IRepository<Order> _orderRepository, IMapper mapper, IRepository<OrderDetils> orderDetilsService, 
            IRepository<Worker> workerRepository, IRepository<Schedule> scheduleRepository, IRepository<Service> serviceRepository, 
            IRepository<Client> clientRepository)
        {
            this._orderRepository = _orderRepository;
            this.mapper = mapper;
            this._workerRepository = workerRepository;
            this._serviceRepository = serviceRepository;
            this._clientRepository = clientRepository;
            _scheduleRepository = scheduleRepository;
            _orderDetilsRepository = orderDetilsService;
        }
        public bool Validate(OrderRequestModel orderRequestModel)
        {
            var isExitsClient = _clientRepository.GetById(orderRequestModel.ClientId);
            if (isExitsClient == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Client));

            var isExitstWorker = _workerRepository.GetById(orderRequestModel.WorkerId);
            if (isExitstWorker == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Worker));
            
            var isExitsOrder = _orderRepository
                            .GetAll()
                            .Where(o => o.WorkerId == orderRequestModel.WorkerId &&
                                  o.Days == orderRequestModel.Days &&
                                  (orderRequestModel.StartTime > o.StartTime &&
                                  orderRequestModel.EndTime < o.EndTime) &&
                                  o.OrderStatus == 1)
                            .Count();
            if (isExitsOrder == 1)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));
            return true;
        }

        public override OrderResponseModel Create(OrderRequestModel orders)
        {
           //Validate(orders);
           var createOrderRequest = orders as CreateOrderRequestModel;
           var entity = mapper.Map<CreateOrderRequestModel, Order>(createOrderRequest);
           entity.EndTime = orders.StartTime.AddMinutes(entity.OrderDetils.Sum(s => s.Service.ExecutionTime));
           _orderRepository.Add(entity);
           _orderRepository.SaveChanges();
            return mapper.Map<Order, CreateOrderResponseModel>(entity);
        }

        public override OrderResponseModel Get(ulong id)
        {   
            return mapper.Map<Order, GetOrderResponseModel>(_orderRepository.GetById(id));
        }

        public override IEnumerable<OrderResponseModel> GetAll()
        {
            var order = _orderRepository.GetAll();

            return mapper.Map<IEnumerable<GetOrderResponseModel>>(order);
        }

        public override OrderResponseModel Update(OrderRequestModel request, ulong id)
        {
            //Validate(request);
            var order = _orderRepository.GetById(id);
            var updateOrderRequest = request as UpdateOrderRequestModel;
            mapper.Map<UpdateOrderRequestModel, Client>(updateOrderRequest);
            _orderRepository.Update(order, id);
            _orderRepository.SaveChanges();
            return mapper.Map<Order, UpdateOrderResponseModel>(order);
        }

        public override bool Delete(ulong id)
        {
            var result = _orderRepository.GetById(id);
            if (result != null)
            {
                _orderRepository.Delete(result);
                _orderRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public (IEnumerable<string> busyTimeWorkers, string scheduleWorker) GetFreeTimesWorker(ulong id)
        {
            var workerSchedule = _scheduleRepository.GetAll().FirstOrDefault(s => s.WorkerId==id);
            var order = _orderRepository.GetAll().Where(w=> w.WorkerId==id);
            var list = new List<string>();
            foreach (var item in order)
            {
                list.Add($"{item.StartTime}-{item.EndTime}");

            }
            return (list,$"{workerSchedule.StartTime}-{workerSchedule.EndTime}");
        }
    }
}
