using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.OrderDetilsRequestModels;
using Queue.Application.Services;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetilsController : ControllerBase
    {
        private readonly IOrderDetilsService _orderDetilsService;

        public OrderDetilsController(IOrderDetilsService orderDetilsService)
        {
            _orderDetilsService = orderDetilsService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_orderDetilsService.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderDetilsService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateOrderDetilsRequestModel request)
        {
            return Ok(_orderDetilsService.Create(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_orderDetilsService.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateOrderDetilsRequestModel order, ulong id)
        {
            return Ok(_orderDetilsService.Update(order, id));
        }
    }
}
