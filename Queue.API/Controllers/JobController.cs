using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.JobRequestModel;
using Queue.Application.RequestModels.QueueFoeServiceRequestModels;
using Queue.Domain.Model;

namespace Queue.API.Controllers;
[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    
    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }
    [HttpGet("{id}")]
    public IActionResult Get(ulong id)
    {
        return Ok(_jobService.Get(id));
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_jobService.GetAll());
    }
    [HttpPost]
    public IActionResult Post(CreateJobRequestModel request)
    {

        return Ok(_jobService.Create(request));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        return Ok(_jobService.Delete(id));
    }
    [HttpPut("{id}")]
    public IActionResult Put(CreateJobRequestModel client, ulong id)
    {
        return Ok(_jobService.Update(client, id));
    }
}