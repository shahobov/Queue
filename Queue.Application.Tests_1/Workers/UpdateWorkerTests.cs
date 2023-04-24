using AutoMapper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.WorkerRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.WorkerResponseModels;
using Queue.Application.Services;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Tests.Workers
{

    public class UpdateWorkerTests
    {
        private readonly Mock<IRepository<Worker>> _workerRepository;
        private readonly Mock<IMapper> _mapper;

        public UpdateWorkerTests()
        {
            _workerRepository = new Mock<IRepository<Worker>>();
            _mapper = new Mock<IMapper>();
        }
        [Test]
        public void Should_update_worker()
        {
            ulong id = 1;
            var workerRequestModel = new UpdateWorkerRequestModel { FirstName = "Asliddin" };
            var workerResponseModel = new UpdateWorkerResponseModel { FirstName = "Asliddin" };
            var worker = new Worker { FirstName = "Asliddin" };

            _mapper.Setup(m => m.Map<UpdateWorkerRequestModel, Worker>(workerRequestModel, worker)).Returns(worker);
            _mapper.Setup(m => m.Map<Worker, UpdateWorkerResponseModel>(worker)).Returns(workerResponseModel);
            _workerRepository.Setup(s => s.GetById(id)).Returns(worker);

            var workerService = new WorkerService(_workerRepository.Object, _mapper.Object);

            var result = workerService.Update(workerRequestModel, id);

            var s = result as UpdateWorkerResponseModel;

            _workerRepository.Verify(r => r.GetById(It.IsAny<ulong>()));
            _workerRepository.Verify(r => r.Update(It.IsAny<Worker>(), (It.IsAny<ulong>())));
            _workerRepository.Verify(r => r.SaveChanges());

            Assert.That(workerRequestModel.FirstName, Is.EqualTo(s.FirstName));
        }

    }
}
