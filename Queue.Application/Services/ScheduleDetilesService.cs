using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ScheduleDetilesRequestModels;
using Queue.Application.ResponseModels.ScheduleDetilesResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class ScheduleDetilesService : BaseService<ScheduleDetails, ScheduleDetailesResponseModel,ScheduleDetilesRequestModel>, IScheduleDetilesService
    {
        private readonly IRepository<ScheduleDetails> _repository;
        private readonly IMapper _mapper;

        public ScheduleDetilesService(IRepository<ScheduleDetails> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override ScheduleDetailesResponseModel Create(ScheduleDetilesRequestModel request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            var createRequestModel = request as CreateScheduleDetilesRequestModel;
            var entity = _mapper.Map<CreateScheduleDetilesRequestModel, ScheduleDetails>(createRequestModel);
            _repository.Add(entity);
            _repository.SaveChanges();
            return _mapper.Map<ScheduleDetails,CreateScheduleDetilesResponseModel>(entity);
        }

        public override ScheduleDetailesResponseModel Get(ulong id)
        {
            return _mapper.Map<ScheduleDetails,ScheduleDetailesResponseModel>(_repository.GetById(id));
        }

        public override IEnumerable<ScheduleDetailesResponseModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GetScheduleDetilesResponseModel>>(_repository.GetAll());
        }

        public override ScheduleDetailesResponseModel Update(ScheduleDetilesRequestModel request, ulong id)
        {
            var schedule = _repository.GetById(id);
            if(schedule == null) throw new ArgumentNullException(nameof(ScheduleDetails));
            var updateScheduleDetailesResponsModel = request as UpdateScheduleDetilesRequestModel;
            _mapper.Map<UpdateScheduleDetilesRequestModel, ScheduleDetails>(updateScheduleDetailesResponsModel);
            _repository.Update(schedule, id);
            _repository.SaveChanges();
            return _mapper.Map<ScheduleDetails,UpdateScheduleDetilesResponseModel>(schedule);
        }

        public override bool Delete(ulong id)
        {
            var result = _repository.GetById(id);
            if(id != null)
            {
                _repository.Delete(result);
                _repository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
