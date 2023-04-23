using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.OrderDetilsRequestModels;
using Queue.Application.ResponseModels.OrderDetilsResponseModels;
using Queue.Domain.Model;
using System.Collections.Generic;

namespace Queue.Application.Services
{
    public class OrderDetilsService : BaseService<OrderDetils,OrderDetilsResponseModel,OrderDetilsRequestModel>, IOrderDetilsService
    {
        private readonly IRepository<OrderDetils> orderDetilsRepository;
        private readonly IRepository<Worker> workerRepository;
        private readonly IRepository<Service> serviceRepository;
        private readonly IRepository<Client> clientRepository;
        private readonly IMapper mapper;

        public OrderDetilsService(IRepository<OrderDetils> orderDetilsRepository, IRepository<Worker> workerRepository, IRepository<Service> serviceRepository, IRepository<Client> clientRepository, IMapper mapper)
        {
            this.orderDetilsRepository = orderDetilsRepository;
            this.workerRepository = workerRepository;
            this.serviceRepository = serviceRepository;
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public bool Validate (OrderDetilsRequestModel orderDetilsRequestModel)
        {
            return true;
        }

        public override OrderDetilsResponseModel Create(OrderDetilsRequestModel orderDetils)
        {
            //Validate(orders);
            var createOrderDetilsRequest = orderDetils as CreateOrderDetilsRequestModel;
            var entity = mapper.Map<CreateOrderDetilsRequestModel, OrderDetils>(createOrderDetilsRequest);
            //entity.EndExequteTimeService = orderDetils.StartServiceTimes.AddMinutes(serviceRepository.GetById(orders.ServiceId).ExecutionTime);
            orderDetilsRepository.Add(entity);
            orderDetilsRepository.SaveChanges();
            return mapper.Map<OrderDetils, CreateOrderDetilsResponseModel>(entity);
        }

        public override OrderDetilsResponseModel Get(ulong id)
        {
            return mapper.Map<OrderDetils, GetOrderDetilsResponseModel>(orderDetilsRepository.GetById(id));
        }

        public override IEnumerable<OrderDetilsResponseModel> GetAll()
        {

            var orderDetils = orderDetilsRepository.GetAll();

            return mapper.Map<IEnumerable<GetOrderDetilsResponseModel>>(orderDetils);
        }

        public override OrderDetilsResponseModel Update(OrderDetilsRequestModel request, ulong id)
        {
            var orderDetils = orderDetilsRepository.GetById(id);
            var updateOrderDetilsRequest = request as UpdateOrderDetilsRequestModel;
            mapper.Map<UpdateOrderDetilsRequestModel, Client>(updateOrderDetilsRequest);
            orderDetilsRepository.Update(orderDetils, id);
            orderDetilsRepository.SaveChanges();
            return mapper.Map<OrderDetils, UpdateOrderDetilsResponseModel>(orderDetils);
        }
        public override bool Delete(ulong id)
        {
            var result = orderDetilsRepository.GetById(id);
            if (result != null)
            {
                orderDetilsRepository.Delete(result);
                orderDetilsRepository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
