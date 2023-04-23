using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.RequestModels.OrderDetilsRequestModels
{
    public abstract class OrderDetilsRequestModel : BaseRequestModel
    {
        public ulong OrderId { get; set; }
        public ulong ServiceId { get; set; }
    }
}
