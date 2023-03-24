using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.WorkerRequestModel;
using Queue.Application.ResponseModels.WorkerResponseModel;
using Queue.Domain.Model;

namespace Queue.Application.Services;

public class WorkerService:BaseService<Worker,WorkerResponseModel,WorkerRequestModel>,IWorkerService
{
    private readonly IRepository<Worker> _repository;
    private readonly IMapper _mapper;

    public WorkerService(IRepository<Worker> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override WorkerResponseModel Create(WorkerRequestModel entity)
    {
        if (entity!=null )
        {
            var schedule = _mapper.Map<WorkerRequestModel, Worker>(entity);
            _repository.Add(schedule);
            _repository.SaveChanges();
            return _mapper.Map<Worker, WorkerResponseModel>(schedule);
        }
        throw new ArgumentNullException(nameof(Worker));
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

    public override WorkerResponseModel Get(ulong id)
    {
        return _mapper.Map<Worker, WorkerResponseModel>(_repository.GetById(id));
    }

    public override WorkerResponseModel Update(WorkerRequestModel entity, ulong id)
    {
        if (entity == null) throw new ArgumentNullException(nameof(Schedule));
        var order = _mapper.Map<WorkerRequestModel, Worker>(entity);
        _repository.Update(order, id);
        return _mapper.Map<Worker, WorkerResponseModel>(order);
    }

    public override WorkerResponseModel GetAll(Worker entity)
    {
        return _mapper.Map<Worker, WorkerResponseModel>(_repository.GetAll(entity));
    }
}