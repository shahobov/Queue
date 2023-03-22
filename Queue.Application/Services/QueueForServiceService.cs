using AutoMapper;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.QueueForServiceResponsModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Services
{
    public class QueueForServiceService: BaseService<QueueForService,QueueForServiceResponsModel,QueueForServiceRequestModel>,IQueueForServiceService
    {
        private readonly IRepository<QueueForService> repository;
        private readonly IMapper mapper;

        public QueueForServiceService(IRepository<QueueForService> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public override QueueForServiceResponsModel Create(QueueForServiceRequestModel request)
        {
            if (request == null) throw new ArgumentNullException();
            var entity = mapper.Map<QueueForServiceRequestModel, QueueForService>(request);
            repository.Add(entity);
            repository.SaveChanges();
            return mapper.Map<QueueForService,QueueForServiceResponsModel>(entity);
        }

        public override QueueForServiceResponsModel Get(ulong id)
        {
            return mapper.Map<QueueForService, QueueForServiceResponsModel>(new QueueForService());
        }

        public override QueueForServiceResponsModel Update(QueueForServiceRequestModel entity, ulong id)
        {
            if(entity == null) throw new ArgumentNullException(nameof(QueueForService));
            return base.Update(entity, id);
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
