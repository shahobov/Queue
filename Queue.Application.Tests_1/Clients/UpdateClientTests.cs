using AutoMapper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.Services;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Tests.Clients
{
    public class UpdateClientTests
    {
        private readonly Mock<IRepository<Client>> _clientRepository;
        private readonly Mock<IMapper> _mapper;

        public UpdateClientTests()
        {
            _clientRepository= new Mock<IRepository<Client>>();
            _mapper= new Mock<IMapper>();
        }
        [Test]
        public void Should_update_client()
        {
            ulong id = 1;
            var clientRequestModel = new UpdateClientRequestModel { FirstName = "Asliddin" };
            var clientResponseModel = new UpdateClientResponseModel { FirstName = "Asliddin" };
            var client = new Client { FirstName = "Asliddin" };

            _mapper.Setup(m => m.Map<UpdateClientRequestModel, Client>(clientRequestModel, client)).Returns(client);
            _mapper.Setup(m => m.Map<Client, UpdateClientResponseModel>(client)).Returns(clientResponseModel);
            _clientRepository.Setup(s => s.GetById(id)).Returns(client);

            var clientService = new ClientService(_clientRepository.Object, _mapper.Object);

            var result = clientService.Update(clientRequestModel, id);

            var s = result as UpdateClientResponseModel;

            _clientRepository.Verify(r => r.GetById(It.IsAny<ulong>()));
            _clientRepository.Verify(r => r.Update(It.IsAny<Client>(), (It.IsAny<ulong>())));
            _clientRepository.Verify(r => r.SaveChanges());

            Assert.That(clientRequestModel.FirstName, Is.EqualTo(s.FirstName));
        }
    }
}
