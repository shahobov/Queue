using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.ScheduleDetilesRequestModels;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleDetailsController : ControllerBase
    {
        private IScheduleDetailsService _service;

        public ScheduleDetailsController(IScheduleDetailsService service)
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
        public IActionResult Post(CreateScheduleDetilesRequestModel scheduleDetilesRequestModel)
        {
            return Ok(_service.Create(scheduleDetilesRequestModel));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateScheduleDetilesRequestModel schedule, ulong id)
        {
            return Ok(_service.Update(schedule,id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
