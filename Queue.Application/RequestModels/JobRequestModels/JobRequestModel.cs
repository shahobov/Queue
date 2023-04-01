using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.RequestModels.JobRequestModels
{
    public abstract class JobRequestModel : BaseRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
