using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.ResponseModels.CategoryResponseModels
{
    public class CreateCategoryResponseModel :CategoryResponseModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
