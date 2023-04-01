using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.JobResponseModels
{
    public class UpdateJobResponseModel : JobResponseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
