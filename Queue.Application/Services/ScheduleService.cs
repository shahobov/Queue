using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ScheduleResquestModels;
using Queue.Application.ResponseModels.ScheduleResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ScheduleService : BaseService<Schedule, ScheduleResponseModel, ScheduleResquestModel>, IScheduleService
    {
        private readonly IRepository<Schedule> _repository;
        private readonly IMapper _mapper;

        public ScheduleService(IRepository<Schedule> scheduleRepository, IMapper mapper)
        {
            _repository = scheduleRepository;
            _mapper = mapper;
        }

        public override ScheduleResponseModel Create(ScheduleResquestModel request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var createScheduleRequestModel = request as CreateScheduleResquestModel;
            var entity = _mapper.Map<CreateScheduleResquestModel, Schedule>(createScheduleRequestModel);
            _repository.Add(entity);
            _repository.SaveChanges();
            return _mapper.Map<Schedule, CreateScheduleResponseModel>(entity);
        }

        public override ScheduleResponseModel Get(ulong id)
        {
            return _mapper.Map<Schedule, GetScheduleResponseModel>(_repository.GetById(id));
        }

        public override IEnumerable<ScheduleResponseModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GetScheduleResponseModel>>(_repository.GetAll());
        }

        public override ScheduleResponseModel Update(ScheduleResquestModel request, ulong id)
        {
            var schedule = _repository.GetById(id);
            if(schedule == null) throw new ArgumentNullException(nameof(schedule));
            var updateScheduleRequest = request as UpdateScheduleResquestModel;
            _mapper.Map<UpdateScheduleResquestModel, Schedule>(updateScheduleRequest);
            _repository.Update(schedule,id);
            _repository.SaveChanges();
            return _mapper.Map<Schedule, UpdateScheduleResponseModel>(schedule);
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
    }
}
