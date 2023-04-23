using Queue.Application.ResponseModels.OrderDetilsResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.OrderResponseModel
{
    public class GetOrderResponseModel : OrderResponseModel
    {
        public ulong ClientId { get; set; }
        public ulong WorkerId { get; set; }
        public List<GetOrderDetilsResponseModel> OrderDetils { get; set; }
        public int Days { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalPrice { get; set; }
        public int OrderStatus { get; set; }
    }
}
