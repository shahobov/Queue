using Microsoft.AspNetCore.Mvc;
using Queue.Application.Common.Interfaces;
using Queue.Application.Common.Interfaces.Repositories;
using Queue.Application.RequestModels.ClientRequestModels;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clientService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateClientRequestModel request)
        {
            return Ok(_clientService.Create(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            return Ok(_clientService.Delete(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateClientRequestModel client, ulong id)
        {
            return Ok(_clientService.Update(client, id));
        }
    }
}
