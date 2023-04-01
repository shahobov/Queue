using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.WorkerRequestModels;
using Queue.Application.RequestModels.WorkerSkillsRequestModels;
using Queue.Application.ResponseModels.WorkerResponseModels;
using Queue.Application.ResponseModels.WorkerSkillsResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class WorkerSkillsService : BaseService<WorkerSkills,WorkerSkillsResponseModel,CreateWorkerSkillsRequestModel>, IWorkerSkillsService
    {
        private readonly IRepository<WorkerSkills> _repository;
        private readonly IMapper _mapper;

        public WorkerSkillsService(IRepository<WorkerSkills> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override WorkerSkillsResponseModel Create(CreateWorkerSkillsRequestModel entity)
        {
            return base.Create(entity);
        }

        public override WorkerSkillsResponseModel Get(ulong id)
        {
            return base.Get(id);
        }

        public override IEnumerable<WorkerSkillsResponseModel> GetAll()
        {
            return base.GetAll();
        }

        public override WorkerSkillsResponseModel Update(CreateWorkerSkillsRequestModel entity, ulong id)
        {
            return base.Update(entity, id);
        }

        public override bool Delete(ulong id)
        {
            return base.Delete(id);
        }
    }
}
