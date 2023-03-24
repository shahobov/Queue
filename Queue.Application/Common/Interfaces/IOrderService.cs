using Queue.Application.RequestModels.OrderRequestModels;
using Queue.Application.ResponseModels.OrderResponseModels;
using Queue.Domain.Model;

namespace Queue.Application.Common.Interfaces
{
    public interface IOrderService : IBaseService<Order, OrderResponsModel, CreateOrderRequestModel>
    {
    }
}
