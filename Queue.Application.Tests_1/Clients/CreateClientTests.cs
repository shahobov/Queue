using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.Services;
using Queue.Application.Validations;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Tests.Clients
{
    public class CreateClientTests
    {
        private readonly Mock<IRepository<Client>> _clientRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly CreateClientValidation _validations;

        public CreateClientTests()
        {
            _clientRepository = new Mock<IRepository<Client>>();
            _mapper = new Mock<IMapper>();
            _validations = new CreateClientValidation();
        }
        [Test]
        public void Create_Client_Test()
        {
            var clientRequestModel = new CreateClientRequestModel { FirstName = "Asliddin" };
            var clientResponseModel = new CreateWorkerResponeModel { FirstName = "Asliddin" };
            var client = new Client { FirstName = "Asliddin" };

            _mapper.Setup(m => m.Map<CreateClientRequestModel, Client>(clientRequestModel)).Returns(client);
            _mapper.Setup(m => m.Map<Client, CreateWorkerResponeModel>(client)).Returns(clientResponseModel);

            var clientService = new ClientService(_clientRepository.Object, _mapper.Object);

            var result = clientService.Create(clientRequestModel);

            var s = result as CreateWorkerResponeModel;

            Assert.IsNotNull(s.FirstName);
        }

        [Test]
        public void Should_have_error_when_Client_FirstName_is_empty()
        {
            var client = new CreateClientRequestModel { FirstName = "" };
            var result = _validations.TestValidate(client);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Test]
        public void Should_have_error_when_Client_FirstName_is_null()
        {
            var client = new CreateClientRequestModel { FirstName = null };
            var result = _validations.TestValidate(client);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }
    }
}
