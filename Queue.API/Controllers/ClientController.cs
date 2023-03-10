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
        private IClientService _clientService;
        private readonly IClientServiceRepositry _repository;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
            
        }
        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {
            return Ok(_clientService.Get(id));
        }
        [HttpGet("{client}")]
        public IActionResult Create(Client client)
        {
            return Ok(_clientService.Create(client));
        }

    }
}
