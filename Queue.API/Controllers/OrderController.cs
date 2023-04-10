using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Domain.Model;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_orderService.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll(Order entity)
        {
            return Ok(_orderService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateOrderRequestModel request)
        {
            return Ok(_orderService.Create(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_orderService.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateOrderRequestModel client, ulong id)
        {
            return Ok(_orderService.Update(client, id));
        }
    }
}
