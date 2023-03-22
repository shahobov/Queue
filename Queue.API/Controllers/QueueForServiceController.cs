using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Application.ResponseModels.QueueForServiceResponsModels;
using Queue.Application.Services;
using Queue.Domain.Model;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueForServiceController : ControllerBase
    {
   
        private IQueueForServiceService _queueForServiceService;

        public QueueForServiceController(IQueueForServiceService queueForServiceService)
        {
            _queueForServiceService = queueForServiceService;

        }
        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_queueForServiceService.Get(id));
        }
       
        [HttpPost]
        public IActionResult Post(CreateQueueForServiceRequestModel request)
        {

            return Ok(_queueForServiceService.Create(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_queueForServiceService.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(CreateQueueForServiceRequestModel createQueueForServiceRequestModel, ulong id)
        {
            return Ok(_queueForServiceService.Update(createQueueForServiceRequestModel, id));
        }
    }
}
