using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.WorkerRequestModels;
using Queue.Application.ResponseModels.WorkerResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class WorkerService : BaseService<Worker,WorkerResponseModel,WorkerRequestModel>, IWorkerService
    {
        private readonly IRepository<Worker> repository;
        private readonly IMapper mapper;

        public WorkerService(IRepository<Worker> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override WorkerResponseModel Create(WorkerRequestModel request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
            var workerRequestModel = request as CreateWorkerRequestModel;
            var entity = mapper.Map<CreateWorkerRequestModel, Worker>(workerRequestModel);
            repository.Add(entity);
            repository.SaveChanges();
            return mapper.Map<Worker,CreateWorkerResponseModel>(entity);
        }

        public override WorkerResponseModel Get(ulong id)
        {
            return mapper.Map<Worker, GetWorkerResponseModel>(repository.GetById(id));
        }

        public override IEnumerable<WorkerResponseModel> GetAll()
        {
            return mapper.Map<IEnumerable<GetWorkerResponseModel>>(repository.GetAll());
        }

        public override WorkerResponseModel Update(WorkerRequestModel request, ulong id)
        {
            var worker = repository.GetById(id);
            if (worker == null) throw new ArgumentNullException(nameof(Worker));
            var updateRequestModel = request as UpdateWorkerRequestModel;
            mapper.Map<UpdateWorkerRequestModel, Worker>(updateRequestModel,worker);
            repository.Update(worker, id);
            repository.SaveChanges();
            return mapper.Map<Worker, UpdateWorkerResponseModel>(worker);
            
        }

        public override bool Delete(ulong id)
        {
            var result = repository.GetById(id);
            if (result != null)
            {
                repository.Delete(result);
                repository.SaveChanges();
                return true;
            }
            return false;
        }
    }   
}
