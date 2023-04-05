using AutoMapper;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.RequestModels.ScheduleDetilesRequestModels;
using Queue.Application.RequestModels.ScheduleResquestModels;
using Queue.Application.RequestModels.ServiceRequestModels;
using Queue.Application.RequestModels.WorkerRequestModels;
using Queue.Application.RequestModels.WorkerSkillsRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Application.ResponseModels.OrderResponseModels;
using Queue.Application.ResponseModels.ScheduleDetilesResponseModels;
using Queue.Application.ResponseModels.ScheduleResponseModels;
using Queue.Application.ResponseModels.ServiceResponseModels;
using Queue.Application.ResponseModels.WorkerResponseModels;
using Queue.Application.ResponseModels.WorkerSkillsResponseModels;
using Queue.Domain.Model;

namespace Queue.Application.Mappers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
             
            CreateMap<CreateClientRequestModel, Client>();
            CreateMap<UpdateClientRequestModel, Client>();
            CreateMap<Client, CreateClientResponeModel>();
            CreateMap<Client, UpdateClientResponseModel>();
            CreateMap<Client, GetClientResponseModel>();


            CreateMap<CreateWorkerRequestModel, Worker>();
            CreateMap<UpdateWorkerRequestModel, Worker>();
            CreateMap<Worker, CreateWorkerResponseModel>();
            CreateMap<Worker, UpdateWorkerResponseModel>();
            CreateMap<Worker, GetWorkerResponseModel>();


            CreateMap<CreateOrderRequestModel, Order>();
            CreateMap<UpdateOrderRequestModel, Order>();
            CreateMap<Order, CreateOrderResponseModel>();
            CreateMap<Order, GetOrderResponseModel>();
            CreateMap<Order, UpdateOrderResponseModel>();


            CreateMap<CreateServiceRequestModel, Service>();
            CreateMap<UpdateServiceRequestModel, Service>();
            CreateMap<Service, CreateServiceResponseModel>();
            CreateMap<Service, UpdateServiceResponseModel>();
            CreateMap<Service, GetServiceResponseModel>();


            CreateMap<CreateJobRequestModel, Job>();
            CreateMap<UpdateJobRequestModel, Job>();    
            CreateMap<Job, CreateJobResponseModel>();
            CreateMap<Job, UpdateJobResponseModel>();
            CreateMap<Job, GetJobResponseModel>();


            CreateMap<CreateScheduleResquestModel, Schedule>();
            CreateMap<UpdateScheduleResquestModel, Schedule>();
            CreateMap<Schedule, CreateScheduleResponseModel>();
            CreateMap<Schedule, UpdateScheduleResponseModel>();
            CreateMap<Schedule, GetScheduleResponseModel>();


            CreateMap<CreateScheduleDetilesRequestModel, ScheduleDetails>();
            CreateMap<UpdateScheduleDetilesRequestModel, ScheduleDetails>();
            CreateMap<ScheduleDetails, CreateScheduleDetilesResponseModel>();
            CreateMap<ScheduleDetails, UpdateScheduleDetilesResponseModel>();
            CreateMap<ScheduleDetails, GetScheduleDetilesResponseModel>();


            CreateMap<CreateWorkerSkillsRequestModel, WorkerSkills>();
            CreateMap<UpdateWorkerSkillsRequestModel, WorkerSkills>();
            CreateMap<WorkerSkills, CreateWorkerSkillsResponseModel>();
            CreateMap<WorkerSkills, UpdateWorkerSkillsResponseModel>();
            CreateMap<WorkerSkills, GetWorkerSkillsResponseModel>();
        }
    }
}
