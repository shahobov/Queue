using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Domain.Model;

namespace Queue.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
            
        }
        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_clientService.Get(id));
        }
        [HttpPost]
        public IActionResult Post(Client client)
        {

            return Ok(_clientService.Create(client));
        }

    }
}
