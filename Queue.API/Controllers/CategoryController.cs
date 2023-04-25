using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.CaregoryRequestModels;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.Services;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categiryService)
        {
            _categoryService = categiryService;
        }


        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_categoryService.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateCategoryRequestModel request)
        {
            return Ok(_categoryService.Create(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_categoryService.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateCategoryRequestModel category, ulong id)
        {
            return Ok(_categoryService.Update(category, id));
        }

    }
}
