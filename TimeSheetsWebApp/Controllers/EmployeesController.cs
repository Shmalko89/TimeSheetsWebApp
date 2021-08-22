using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Models.Token;
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
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            TokenResponse token = _repository.Authenticate(user, password);
            if (token is null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }
        [Authorize]
        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            string newRefreshToken = _repository.RefreshToken(oldRefreshToken);

            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);
            return Ok(newRefreshToken);
        }
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

    }
}

