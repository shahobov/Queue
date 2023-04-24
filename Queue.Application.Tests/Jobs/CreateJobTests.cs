using AutoMapper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.Services;
using Queue.Domain.Model;

namespace Queue.Application.Tests.Jobs
{
    public class CreateJobTests
    {
        private readonly Mock< IRepository<Job>> _repository;
        private readonly Mock<IMapper> _mapper;

        public CreateJobTests()
        {
            _repository= new Mock<IRepository<Job>>();
            _mapper= new Mock<IMapper>();
        }

        [Test]
        public void Create_Job_Test()
        {
            var jobRequestModel = new CreateJobRequestModel { Description = "description" };
            var jobResponseModel = jobRequestModel;

            var jobService = new JobService(_repository.Object, _mapper.Object);

            var result = jobService.Create(jobRequestModel);

            Assert.IsNotNull(result);
        }
    }
}
