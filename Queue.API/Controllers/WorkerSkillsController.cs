using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.WorkerSkillsRequestModel;

namespace Queue.API.Controllers;
[ApiController]
[Route("[controller]")]
public class WorkerSkillsController:ControllerBase
{
    private readonly IWorkerSkillsService _workerSkillsService;

    public WorkerSkillsController(IWorkerSkillsService workerSkillsService)
    {
        _workerSkillsService = workerSkillsService;
    }
    [HttpGet("{id}")]
    public IActionResult Get(ulong id)
    {
        return Ok(_workerSkillsService.Get(id));
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_workerSkillsService.GetAll());
    }
    [HttpPost]
    public IActionResult Post(CreateWorkerSkillsRequestModel request)
    {

        return Ok(_workerSkillsService.Create(request));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        return Ok(_workerSkillsService.Delete(id));
    }
    [HttpPut("{id}")]
    public IActionResult Put(CreateWorkerSkillsRequestModel client, ulong id)
    {
        return Ok(_workerSkillsService.Update(client, id));
    }
}