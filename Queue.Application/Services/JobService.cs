using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class JobService : BaseService<Job,JobResponseModel,JobRequestModel>, IJobService
    {
        private readonly IRepository<Job> _repository;
        private readonly IMapper _mapper;
        public JobService(IRepository<Job> repository, IMapper mapper)
        {
           _repository= repository;
            _mapper= mapper;
        }
        public override JobResponseModel Create(JobRequestModel request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            var createRequestModel = request as CreateJobRequestModel;
            var entity = _mapper.Map<CreateJobRequestModel,Job>(createRequestModel);
            _repository.Add(entity);
            _repository.SaveChanges();
            return _mapper.Map<Job,CreateJobResponseModel>(entity);
        }

        public override GetJobResponseModel Get(ulong id)
        {
            return _mapper.Map<Job, GetJobResponseModel>(_repository.GetById(id));
        }

        public override IEnumerable<JobResponseModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GetJobResponseModel>>(_repository.GetAll());
        }

        public override JobResponseModel Update(JobRequestModel request, ulong id)
        {
            var job = _repository.GetById(id);
            if(job == null) throw new ArgumentNullException(nameof(Job));
            var updateJobRequest = request as UpdateJobRequestModel;
            _mapper.Map<UpdateJobRequestModel,Job>(updateJobRequest,job);
            _repository.Update(job,id);
            _repository.SaveChanges();
            return _mapper.Map<Job,UpdateJobResponseModel>(job);
        }

        public override bool Delete(ulong id)
        {
            var entity = _repository.GetById(id);
            if(entity == null) throw new ArgumentNullException(nameof(Job));
            if(entity != null)
            {
                _repository.Delete(entity);
                _repository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
