using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Application.Services;
using Queue.Application.Validations;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Tests.Orders
{
    public class CreateOrderTests
    {
        private readonly Mock<IRepository<Order>> _orderRepository;
        private readonly Mock<IRepository<Worker>> _workerRepository;
        private readonly Mock<IRepository<Service>> _serviceRepository;
        private readonly Mock<IRepository<Client>> _clientRepository;
        private readonly Mock<IRepository<Schedule>> _scheduleRepository;
        private readonly Mock<IRepository<OrderDetils>> _orderDetilsRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly OrderValidation _validations;

        public CreateOrderTests()
        {
            _mapper = new Mock<IMapper>();
            _orderRepository = new Mock<IRepository<Order>>();
            _validations = new OrderValidation();
            _workerRepository = new Mock<IRepository<Worker>>();
            _serviceRepository = new Mock<IRepository<Service>>();
            _clientRepository = new Mock<IRepository<Client>>();
            _scheduleRepository = new Mock<IRepository<Schedule>>();
            _orderDetilsRepository = new Mock<IRepository<OrderDetils>>();
        }
        [Test]
        public void Create_Order_Test()
        {
            var service = new Service { ExecutionTime=20 };
            var orderDetils = new OrderDetils { Service=service};
            var orderDetiles = new List<OrderDetils>();
            orderDetiles.Add(orderDetils);
            var orderRequestModel = new CreateOrderRequestModel { ClientId = 1, StartTime=DateTime.Parse("2023-04-24T15:57:22.936Z") };
            var orderResponseModel = new CreateOrderResponseModel { ClientId = 1 };
            var order = new Order { ClientId = 1,OrderDetils=orderDetiles };

            _mapper.Setup(m => m.Map<CreateOrderRequestModel, Order>(orderRequestModel)).Returns(order);
            _mapper.Setup(m => m.Map<Order, CreateOrderResponseModel>(order)).Returns(orderResponseModel);
            
            var orderService = new OrderService(_orderRepository.Object, _mapper.Object, _orderDetilsRepository.Object,
            _workerRepository.Object, _scheduleRepository.Object, _serviceRepository.Object, _clientRepository.Object);


            var result = orderService.Create(orderRequestModel);

            var entity = result as CreateOrderResponseModel;

            Assert.IsNotNull(entity.ClientId);
        }

        [Test]
        public void Should_have_error_when_Order_ClientId_is_Zero()
        {
            var product = new CreateOrderRequestModel { ClientId = 0 };
            var result = _validations.TestValidate(product);
            result.ShouldHaveValidationErrorFor(x => x.ClientId);
        }
    }
}
