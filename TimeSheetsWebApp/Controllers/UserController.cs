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
    [Route("api/timesheets/users")]

    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }


        [HttpGet("read")]
        public IActionResult GetListUsers()
        {
            _repository.GetList();
            return Ok();
        }

        [HttpPut("create")]
        public IActionResult CreateUser([FromBody] Users user)
        {
            IOperationResult<Users> result = _repository.Create(user);
            if (result.Succeed)
            {
                return Created(new Uri($"users/{result.Result}"), result);
            }
        }
    }
}
       
