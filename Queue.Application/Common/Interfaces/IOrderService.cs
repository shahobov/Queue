using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.OrderResponseModel;
using Queue.Domain.Model;

namespace Queue.Application.Common.Interfaces
{
    public interface IOrderService : IBaseService<Order, OrderResponseModel, OrderRequestModel>
    {
    }
}
