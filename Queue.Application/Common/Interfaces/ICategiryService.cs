using Queue.Application.RequestModels.CaregoryRequestModels;
using Queue.Application.ResponseModels.CategoryResponseModels;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Common.Interfaces
{
    public interface ICategoryService : IBaseService<Category,CategoryResponseModel,CategoryRequestModel>
    {
    }
}
