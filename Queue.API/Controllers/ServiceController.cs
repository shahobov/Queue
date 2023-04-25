using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.RequestModels.ServiceRequestModels;
using Queue.Application.Services;
using Queue.Domain.Model;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _service;

        public ServiceController(IServicesService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public IActionResult Post(CreateServiceRequestModel createServiceRequestModel)
        {
            return Ok(_service.Create(createServiceRequestModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_service.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateServiceRequestModel service, ulong id)
        {
            return Ok(_service.Update(service, id));
        }
    }
}
