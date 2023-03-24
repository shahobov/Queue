using System;
using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ScheduleRequestModel;
using Queue.Application.ResponseModels.ScheduleResponseModel;
using Queue.Domain.Model;

namespace Queue.Application.Services;

public class ScheduleService:BaseService<Schedule,ScheduleResponseModel,ScheduleRequestModel>,IScheduleService
{
    private readonly IRepository<Schedule> _repository;
    private readonly IMapper _mapper;

    public ScheduleService(IRepository<Schedule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override ScheduleResponseModel Create(ScheduleRequestModel entity)
    {
        if (entity!=null )
        {
            var schedule = _mapper.Map<ScheduleRequestModel, Schedule>(entity);
            _repository.Add(schedule);
            _repository.SaveChanges();
            return _mapper.Map<Schedule, ScheduleResponseModel>(schedule);
        }
        throw new ArgumentNullException(nameof(Schedule));
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

    public override ScheduleResponseModel Get(ulong id)
    {
        return _mapper.Map<Schedule, ScheduleResponseModel>(_repository.GetById(id));
    }

    public override ScheduleResponseModel Update(ScheduleRequestModel entity, ulong id)
    {
        if (entity == null) throw new ArgumentNullException(nameof(Schedule));
        var order = _mapper.Map<ScheduleRequestModel, Schedule>(entity);
        _repository.Update(order, id);
        return _mapper.Map<Schedule, ScheduleResponseModel>(order);
    }

    public override ScheduleResponseModel GetAll(Schedule entity)
    {
        return _mapper.Map<Schedule, ScheduleResponseModel>(_repository.GetAll(entity));
    }
}