using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.ScheduleResquestModels;
using Queue.Application.ResponseModels.ScheduleResponseModels;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ScheduleController : ControllerBase
    {
        private IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_scheduleService.Get(id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_scheduleService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateScheduleResquestModel request)
        {
            return Ok(_scheduleService.Create(request));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateScheduleResquestModel request, ulong id)
        {
            return Ok(_scheduleService.Update(request, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_scheduleService.Delete(id));
        }
    }
}
