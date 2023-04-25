using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.RequestModels.JobRequestModels;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private IJobService _jobService;

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
        public IActionResult Post(CreateJobRequestModel job)
        {
            return Ok(_jobService.Create(job));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_jobService.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateJobRequestModel job, ulong id)
        {
            return Ok(_jobService.Update(job, id));
        }
    }
}
