using Queue.Domain.Model;

namespace Queue.Application.ResponseModels.OrderResponseModels
{
    public class OrderResponsModel : BaseResponseModel
    {
        public Service Service { get; set; }
        public Client Client { get; set; }
        public Worker Worker { get; set; }
        public ulong PositionQueueId { get; set; }
        public int QueueStatus { get; set; }
    }
}
