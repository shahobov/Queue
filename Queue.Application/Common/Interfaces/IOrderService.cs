using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.OrderResponsModel;
using Queue.Domain.Model;

namespace Queue.Application.Common.Interfaces
{
    public interface IOrderService : IBaseService<Order, OrderResponsModel, CreateOrderRequestModel>
    {
    }
}
