using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.ServiceResponseModels
{
    public class GetServiceResponseModel : ServiceResponseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public decimal Price { get; set; }
    }
}
