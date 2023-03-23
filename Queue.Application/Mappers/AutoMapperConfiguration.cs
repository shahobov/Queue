using AutoMapper;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Application.ResponseModels.OrderResponsModel;
using Queue.Domain.Model;

namespace Queue.Application.Mappers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<Client, ClientResponseModel>();    
            CreateMap<CreateClientRequestModel, Client>();

            CreateMap<Order,OrderResponsModel>();
            CreateMap<OrderRequestModel, Order>();
        }
    }
}
