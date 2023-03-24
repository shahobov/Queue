using System;
using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.WorkerSkillsRequestModel;
using Queue.Application.ResponseModels.WorkerSkillsResponseModel;
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

    public override WorkerSkillsResponseModel Create(WorkerSkillsRequestModel entity)
    {
        if (entity!=null )
        {
            var schedule = _mapper.Map<WorkerSkillsRequestModel, WorkerSkills>(entity);
            _repository.Add(schedule);
            _repository.SaveChanges();
            return _mapper.Map<WorkerSkills, WorkerSkillsResponseModel>(schedule);
        }
        throw new ArgumentNullException(nameof(WorkerSkills));
    }

    public override bool Delete(ulong id)
    {
        var schedule = _repository.GetById(id);
        if (schedule!=null)
        {
            return true;
        }

        return false;
    }

    public override WorkerSkillsResponseModel Get(ulong id)
    {
        return _mapper.Map<WorkerSkills, WorkerSkillsResponseModel>(_repository.GetById(id));
    }

    public override WorkerSkillsResponseModel Update(WorkerSkillsRequestModel entity, ulong id)
    {
       
        if (entity == null) throw new ArgumentNullException(nameof(WorkerSkills));
        var order = _mapper.Map<WorkerSkillsRequestModel, WorkerSkills>(entity);
        _repository.Update(order, id);
        return _mapper.Map<WorkerSkills, WorkerSkillsResponseModel>(order);
    }

    public override WorkerSkillsResponseModel GetAll(WorkerSkills entity)
    {
        return _mapper.Map<WorkerSkills, WorkerSkillsResponseModel>(_repository.GetAll(entity));
    }
    
}