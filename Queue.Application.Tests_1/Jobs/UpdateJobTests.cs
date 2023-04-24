using AutoMapper;
using Moq;
using NUnit.Framework;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.Services;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Tests.Jobs
{
    public class UpdateJobTests
    {
        private readonly Mock<IRepository<Job>> _repository;
        private readonly Mock<IMapper> _mapper;
        public UpdateJobTests()
        {
            _repository= new Mock<IRepository<Job>>();
            _mapper= new Mock<IMapper>();
        }

        [Test]
        public void Should_update_job() 
        {
            ulong id = 1;
            var jobRequestModel = new UpdateJobRequestModel { Description = "description" };
            var jobResponseModel = new UpdateJobResponseModel { Description = "description" };
            var job = new Job { Description = "description" };

            _mapper.Setup(m => m.Map<UpdateJobRequestModel, Job>(jobRequestModel, job)).Returns(job);
            _mapper.Setup(m => m.Map<Job, UpdateJobResponseModel>(job)).Returns(jobResponseModel);
            _repository.Setup(s => s.GetById(id)).Returns(job);

            var jobService = new JobService(_repository.Object, _mapper.Object);

            var result = jobService.Update(jobRequestModel, id);

            var s = result as UpdateJobResponseModel;

            _repository.Verify(r=>r.GetById(It.IsAny<ulong>()));
            _repository.Verify(r=>r.Update(It.IsAny<Job>(), (It.IsAny<ulong>())));
            _repository.Verify(r=>r.SaveChanges());

            Assert.That(jobRequestModel.Description, Is.EqualTo(s.Description));
        }
    }
}
