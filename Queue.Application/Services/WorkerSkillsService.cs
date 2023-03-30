using System;
using System.Collections.Generic;
using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels;
using Queue.Application.RequestModels.WorkerSkillsRequestModel;
using Queue.Application.ResponseModels.WorkerSkillsResponseModels;
using Queue.Domain.Model;

namespace Queue.Application.Services;

public class WorkerSkillsService:BaseService<WorkerSkills,WorkerSkillsResponseModel,WorkerSkillsRequestModel>,IWorkerSkillsService
{
    private readonly IRepository<WorkerSkills> _repository;
    private readonly IMapper _mapper;

    public WorkerSkillsService(IRepository<WorkerSkills> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override WorkerSkillsResponseModel Create(WorkerSkillsRequestModel request)
    {
        if (request == null) throw new ArgumentNullException(nameof(WorkerSkills));

        var creatClientRequest = request as CreateWorkerSkillsRequestModel;

        var entity = _mapper.Map<CreateWorkerSkillsRequestModel, WorkerSkills>(creatClientRequest);
        _repository.Add(entity);
        _repository.SaveChanges();
        return _mapper.Map<WorkerSkills, CreateWorkerSkillsResponseModel>(entity);
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

    public override WorkerSkillsResponseModel Get(ulong id)
    {
        return _mapper.Map<WorkerSkills, GetWorkerSkillsResponseModel>(_repository.GetById(id));
    }

    public override WorkerSkillsResponseModel Update(WorkerSkillsRequestModel request, ulong id)
    {
       
        var client = _repository.GetById(id);
        if (client == null) throw new ArgumentNullException(nameof(Client));
        var updateClientRequest = request as UpdateWorkerSkillsRequestModel;
        client = _mapper.Map<UpdateWorkerSkillsRequestModel, WorkerSkills>(updateClientRequest);
        _repository.Update(client,id);
        _repository.SaveChanges();
        return _mapper.Map<WorkerSkills, UpdateWorkerSkillsResponseModel>(client);
    }

    public override IEnumerable<WorkerSkillsResponseModel> GetAll()
    {
        return _mapper.Map<IEnumerable<GetWorkerSkillsResponseModel>>(_repository.GetAll());
    }
}

