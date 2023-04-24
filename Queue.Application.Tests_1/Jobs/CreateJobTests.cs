using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.Services;
using Queue.Domain.Model;

namespace Queue.Application.Tests.Jobs
{
    public class CreateJobTests
    {
        private readonly Mock< IRepository<Job>> _repository;
        private readonly Mock<IMapper> _mapper;
        private readonly CreateJpbValidation _validations;

        public CreateJobTests()
        {
            _repository= new Mock<IRepository<Job>>();
            _mapper= new Mock<IMapper>();
            _validations= new CreateJpbValidation();
        }

        [Test]
        public void Create_Job_Test()
        {
            var jobRequestModel = new CreateJobRequestModel { Description = "description" };
            var jobResponseModel = new CreateJobResponseModel { Description = "description" };
            var job = new Job { Description = "description" };

            _mapper.Setup(m => m.Map<CreateJobRequestModel, Job>(jobRequestModel)).Returns(job);
            _mapper.Setup(m => m.Map<Job, CreateJobResponseModel>(job)).Returns(jobResponseModel);

            var jobService = new JobService(_repository.Object, _mapper.Object);

            var result = jobService.Create(jobRequestModel);

            var s= result as CreateJobResponseModel;

            Assert.IsNotNull(s.Description);
        }

        [Test]
        public void Should_have_error_when_Job_Name_is_empty()
        {
            var product = new CreateJobRequestModel { Name = "" };
            var result = _validations.TestValidate(product);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void Should_have_error_when_Job_Name_is_null()
        {
            var product = new CreateJobRequestModel { Name = null };
            var result = _validations.TestValidate(product);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }
    }
}
