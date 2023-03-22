using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.RequestModels.QueueFoeServiceRequestModels
{
    public class QueueForServiceRequestModel : BaseRequestModel
    {
        public ulong Id { get; set; }
        public Service Service { get; set; }
      
        public Client Client { get; set; }
       
        public Worker Worker { get; set; }
        public ulong PositionQueueId { get; set; }
        public int QueueStatus { get; set; }
    }
}
