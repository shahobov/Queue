using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.WorkerRequestModel;
using Queue.Application.RequestModels.WorkerSkillsRequestModel;
using Queue.Domain.Model;

namespace Queue.API.Controllers;
[ApiController]
[Route("[controller]")]
public class WorkerController:ControllerBase
{
    private readonly IWorkerService _workerService;

    public WorkerController(IWorkerService workerService)
    {
        _workerService = workerService;
    }
    [HttpGet("{id}")]

    public IActionResult Get(ulong id)
    {
        return Ok(_workerService.Get(id));
    }
    [HttpGet]
    public IActionResult GetAll(Worker entity)
    {
        return Ok(_workerService.GetAll(entity));
    }
    [HttpPost]
    public IActionResult Add(WorkerRequestModel request)
    {

        return Ok(_workerService.Create(request));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        return Ok(_workerService.Delete(id));
    }
    [HttpPut("{id}")]
    public IActionResult Update(WorkerRequestModel client, ulong id)
    {
        return Ok(_workerService.Update(client, id));
    }
}