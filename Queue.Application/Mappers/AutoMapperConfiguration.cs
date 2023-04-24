using AutoMapper;
using Queue.Application.RequestModels.CaregoryRequestModels;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.JobRequestModels;
using Queue.Application.RequestModels.OrderDetilsRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.RequestModels.ScheduleResquestModels;
using Queue.Application.RequestModels.ServiceRequestModels;
using Queue.Application.RequestModels.WorkerRequestModels;
using Queue.Application.RequestModels.WorkerSkillsRequestModels;
using Queue.Application.ResponseModels.CategoryResponseModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.JobResponseModels;
using Queue.Application.ResponseModels.OrderDetilsResponseModels;
using Queue.Application.ResponseModels.OrderResponseModel;
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
            CreateMap<Client, CreateWorkerResponeModel>();
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


            CreateMap<CreateOrderDetilsRequestModel, OrderDetils>();
            CreateMap<UpdateOrderDetilsRequestModel, OrderDetils>();
            CreateMap<OrderDetils, CreateOrderDetilsResponseModel>();
            CreateMap<OrderDetils, GetOrderDetilsResponseModel>();
            CreateMap<OrderDetils, UpdateOrderDetilsResponseModel>();


            CreateMap<CreateServiceRequestModel, Service>();
            CreateMap<UpdateServiceRequestModel, Service>();
            CreateMap<Service, CreateServiceResponseModel>();
            CreateMap<Service, UpdateServiceResponseModel>();
            CreateMap<Service, GetServiceResponseModel>();


            CreateMap<CreateCategoryRequestModel, Category>();
            CreateMap<UpdateCategoryRequestModel, Category>();
            CreateMap<Category, CreateCategoryResponseModel>();
            CreateMap<Category, UpdateCategoryResponseModel>();
            CreateMap<Category, GetCategoryResponseModel>();


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


            CreateMap<CreateWorkerSkillsRequestModel, WorkerSkills>();
            CreateMap<UpdateWorkerSkillsRequestModel, WorkerSkills>();
            CreateMap<WorkerSkills, CreateWorkerSkillsResponseModel>();
            CreateMap<WorkerSkills, UpdateWorkerSkillsResponseModel>();
            CreateMap<WorkerSkills, GetWorkerSkillsResponseModel>();
        }
    }
}
