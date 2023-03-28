using AutoMapper;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.RequestModels.ServiceRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Application.ResponseModels.OrderResponseModels;
using Queue.Application.ResponseModels.ServiceResponseModels;
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
                

            CreateMap<CreateOrderRequestModel, Order>();
            CreateMap<UpdateOrderRequestModel, Order>();
            CreateMap<Order, CreateOrderResponseModel>();
            CreateMap<Order, GetOrderResponseModel>();
            CreateMap<Order, UpdateOrderResponseModel>();





            CreateMap<Service, ServiceResponseModel>();
            CreateMap<ServiceRequestModel, Service>();
        }
    }
}
