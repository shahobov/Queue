using AutoMapper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Application.Services;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Tests.Orders
{
    public class UpdateOrderTests
    {
        private readonly Mock<IRepository<Order>> _orderRepository;
        private readonly Mock<IRepository<Worker>> _workerRepository;
        private readonly Mock<IRepository<Service>> _serviceRepository;
        private readonly Mock<IRepository<Client>> _clientRepository;
        private readonly Mock<IRepository<Schedule>> _scheduleRepository;
        private readonly Mock<IRepository<OrderDetils>> _orderDetilsRepository;
        private readonly Mock<IMapper> _mapper;

        public UpdateOrderTests()
        {
            _mapper= new Mock<IMapper>();
            _orderRepository= new Mock<IRepository<Order>>();
            _workerRepository = new Mock<IRepository<Worker>>();
            _serviceRepository = new Mock<IRepository<Service>>();
            _clientRepository = new Mock<IRepository<Client>>();
            _scheduleRepository = new Mock<IRepository<Schedule>>();
            _orderDetilsRepository = new Mock<IRepository<OrderDetils>>();
        }
        [Test]
        public void Should_Update_Order()
        {
            ulong id = 1;
            var orderRequestModel = new UpdateOrderRequestModel { ClientId = 1 };
            var orderResponseModel = new UpdateOrderResponseModel { ClientId = 1 };
            var order = new Order { ClientId = 1 };

            _mapper.Setup(m => m.Map<UpdateOrderRequestModel, Order>(orderRequestModel, order)).Returns(order);
            _mapper.Setup(m => m.Map<Order, UpdateOrderResponseModel>(order)).Returns(orderResponseModel);
            _orderRepository.Setup(s => s.GetById(id)).Returns(order);

            var orderService = new OrderService(_orderRepository.Object, _mapper.Object, _orderDetilsRepository.Object,
                                                  _workerRepository.Object, _scheduleRepository.Object, _serviceRepository.Object, _clientRepository.Object);
            var result = orderService.Update(orderRequestModel, id);

            var s = result as UpdateOrderResponseModel;

            _orderRepository.Verify(r => r.GetById(It.IsAny<ulong>()));
            _orderRepository.Verify(r => r.Update(It.IsAny<Order>(), (It.IsAny<ulong>())));
            _orderRepository.Verify(r => r.SaveChanges());

            Assert.That(orderRequestModel.ClientId, Is.EqualTo(s.ClientId));
        }
    }
}
