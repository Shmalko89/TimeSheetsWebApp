using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Repositories.Interfaces;

namespace TimeSheetsWebApp.Controllers
{
    [ApiController]
    [Route("api/timesheets/clients")]

    public class ClientsController : ControllerBase
    {
        private readonly IClientRepo _repository;

        public ClientsController (IClientRepo repository)
        {
            _repository = repository;
        }


        [HttpGet("read")]
        public IActionResult GetListClients()
        {
            _repository.GetList();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateClient([FromQuery] Client input)
        {
            _repository.Create(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateClient([FromQuery] Client client, [FromQuery] Client clientToUpdate)
        {
            _repository.Update(client, clientToUpdate);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteClient([FromQuery] Client clientToDelete)
        {
            _repository.Delete(clientToDelete);
            return Ok();
        }

    }
}
