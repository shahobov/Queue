using System;
using System.Collections.Generic;
using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.JobRequestModel;
using Queue.Application.ResponseModels.JobResponseModel;
using Queue.Domain.Model;

namespace Queue.Application.Services;

public class JobService:BaseService<Job,JobResponseModel,JobRequestModel>,IJobService
{
    private readonly IRepository<Job> _repository;
    private readonly IMapper _mapper;

    public JobService(IRepository<Job> repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override JobResponseModel Get(ulong id)
    {
        return _mapper.Map<Job, GetJobResponseModel>(_repository.GetById(id));
    }

    public override JobResponseModel Create(JobRequestModel request)
    {
        if (request == null) throw new ArgumentNullException(nameof(Job));
        var creatClientRequest = request as CreateJobRequestModel;

        var entity = _mapper.Map<CreateJobRequestModel, Job>(creatClientRequest);
        _repository.Add(entity);
        _repository.SaveChanges();
        return _mapper.Map<Job, CreateJobResponseModel>(entity);
    }

    public override bool Delete(ulong id)
    {
        var result = _repository.GetById(id);
        if (result != null)
        {
            _repository.Delete(result);
            _repository.SaveChanges();
            return true;
        }
        return false;
    }

    public override JobResponseModel Update(JobRequestModel request, ulong id)
    {
        var job = _repository.GetById(id);
        if (job == null) throw new ArgumentNullException(nameof(Job));
        var updateClientRequest = request as UpdateJobRequestModel;
        _mapper.Map<UpdateJobRequestModel, Job>(updateClientRequest);
        _repository.Update(job,id);
        _repository.SaveChanges();
        return _mapper.Map<Job, UpdateJobResponseModel>(job);
    }

    public override IEnumerable<JobResponseModel> GetAll()
    {
        var jobs = _repository.GetAll();
        
        return _mapper.Map<IEnumerable<GetJobResponseModel>>(jobs);
    }
    
}