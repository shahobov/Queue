using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.WorkerRequestModels;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet("{id}")]
        public IActionResult Get( ulong Id)
        {
            return Ok(_workerService.Get(Id));
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_workerService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateWorkerRequestModel worker)
        {
            return Ok(_workerService.Create(worker));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong Id)
        {
            return Ok(_workerService.Delete(Id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateWorkerRequestModel worker, ulong Id)
        {
            return Ok(_workerService.Update(worker, Id));
        }
    }
}
