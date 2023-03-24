using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.ScheduleRequestModel;
using Queue.Domain.Model;

namespace Queue.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

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
    public IActionResult GetAll(Schedule entity)
    {
        return Ok(_scheduleService.GetAll(entity));
    }
    [HttpPost]
    public IActionResult Add(ScheduleRequestModel request)
    {

        return Ok(_scheduleService.Create(request));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        return Ok(_scheduleService.Delete(id));
    }
    [HttpPut("{id}")]
    public IActionResult Update(ScheduleRequestModel client, ulong id)
    {
        return Ok(_scheduleService.Update(client, id));
    }
}