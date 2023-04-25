using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.WorkerRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.WorkerResponseModels;
using Queue.Application.Services;
using Queue.Application.Validations;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Tests.Workers
{
    public class CreateWorkerTests
    {
        private readonly Mock<IRepository<Worker>> _workerRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly WorkerValidation _validations;

        public CreateWorkerTests()
        {
            _workerRepository = new Mock<IRepository<Worker>>();
            _mapper = new Mock<IMapper>();
            _validations = new WorkerValidation();
        }
        [Test]
        public void Create_Client_Test()
        {
            var workerRequestModel = new CreateWorkerRequestModel { FirstName = "Asliddin" };
            var workerResponseModel = new CreateWorkerResponseModel { FirstName = "Asliddin" };
            var worker = new Worker { FirstName = "Asliddin" };

            _mapper.Setup(m => m.Map<CreateWorkerRequestModel, Worker>(workerRequestModel)).Returns(worker);
            _mapper.Setup(m => m.Map<Worker, CreateWorkerResponseModel>(worker)).Returns(workerResponseModel);

            var workerService = new WorkerService(_workerRepository.Object, _mapper.Object);

            var result = workerService.Create(workerRequestModel);

            var entity = result as CreateWorkerResponseModel;

            Assert.IsNotNull(entity.FirstName);
        }

        [Test]
        public void Should_have_error_when_Client_FirstName_is_empty()
        {
            var worker = new CreateWorkerRequestModel { FirstName = "" };
            var result = _validations.TestValidate(worker);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Test]
        public void Should_have_error_when_Client_FirstName_is_null()
        {
            var worker = new CreateWorkerRequestModel { FirstName = null };
            var result = _validations.TestValidate(worker);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }
    }
}
