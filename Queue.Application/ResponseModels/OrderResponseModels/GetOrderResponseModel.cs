using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.OrderResponseModel
{
    public class GetOrderResponseModel : OrderResponsModel
    {
        public ulong ServiceId { get; set; }
        public ulong ClientId { get; set; }

        public ulong WorkerId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StartServiceTimes { get; set; }
        public DateTime EndExequteTimeService { get; set; }
        public int QueueStatus { get; set; }
    }
}
