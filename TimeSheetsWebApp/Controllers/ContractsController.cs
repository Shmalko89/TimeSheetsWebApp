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
    [Route("api/timesheets/contracts")]

    public class ContractsController : ControllerBase
    {
        private readonly IContractRepo _repository;

        public ContractsController(IContractRepo repository)
        {
            _repository = repository;
        }


        [HttpGet("read")]
        public IActionResult GetListContracts()
        {
            _repository.GetList();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateClient([FromQuery] Contract input)
        {
            _repository.Create(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateClient([FromQuery] Contract contract, [FromQuery] Contract contractToUpdate)
        {
            _repository.Update(contract, contractToUpdate);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteClient([FromQuery] Contract contractToDelete)
        {
            _repository.Delete(contractToDelete);
            return Ok();
        }

    }
}

