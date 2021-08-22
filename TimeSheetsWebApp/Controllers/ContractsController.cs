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

