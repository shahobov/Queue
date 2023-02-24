using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_clientService.Get(id));
        }
    }
}
