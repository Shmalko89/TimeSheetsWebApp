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
    [Route("api/timesheets/employee")]

    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;

        public EmployeesController(IEmployeeRepo repository)
        {
            _repository = repository;
        }


        [HttpGet("read")]
        public IActionResult GetListEmployee()
        {
            _repository.GetList();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateCEmployee([FromQuery] Employee input)
        {
            _repository.Create(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateClient([FromQuery] Employee employee, [FromQuery] Employee employeeToUpdate)
        {
            _repository.Update(employee, employeeToUpdate);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteClient([FromQuery] Employee employeeToDelete)
        {
            _repository.Delete(employeeToDelete);
            return Ok();
        }

    }
}

