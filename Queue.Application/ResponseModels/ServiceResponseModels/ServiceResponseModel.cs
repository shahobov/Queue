using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.ServiceResponseModels
{
    public class ServiceResponseModel:BaseResponseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExecutionTime { get; set; }
        public decimal Price { get; set; }
    }
}
