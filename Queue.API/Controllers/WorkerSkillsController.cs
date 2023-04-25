using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.WorkerSkillsRequestModels;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerSkillsController : ControllerBase
    {
        private IWorkerSkillsService _workerSkillsService;

        public WorkerSkillsController(IWorkerSkillsService workerSkillsService)
        {
            _workerSkillsService = workerSkillsService;
        }

        [HttpGet("{id}")]
        public IActionResult Get( ulong id)
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

        [HttpPut("{id}")]
        public IActionResult Put(UpdateWorkerSkillsRequestModel request, ulong id)
        {
            return Ok(_workerSkillsService.Update(request, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_workerSkillsService.Delete(id));
        }
    }
}
