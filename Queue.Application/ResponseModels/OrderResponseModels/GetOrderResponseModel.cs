using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.OrderResponseModel
{
    public class GetOrderResponseModel : OrderResponseModel
    {
        public ulong ServiceId { get; set; }
        public ulong ClientId { get; set; }
        public ulong WorkerId { get; set; }
        public DateTime QueueTimes { get; set; }
        public int QueueStatus { get; set; }
    }
}
