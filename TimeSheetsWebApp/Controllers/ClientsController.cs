using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetsWebApp.Controllers
{
    [ApiController]
    [Route("api/timesheets/clients")]

    public class ClientsController : ControllerBase
    {
        List<string> data = new List<string>();

        [HttpGet("read")]
        public IActionResult GetListClients()
        {
            foreach (string d in data)
            {
                Console.WriteLine(d);
            }
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateClient([FromQuery] string input)
        {
            data.Add(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateClient([FromQuery] string stringToUpdate, [FromQuery] string newString)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == stringToUpdate)
                    data[i] = newString;
            }

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteClient([FromQuery] string stringToDelete)
        {
            data.Remove(stringToDelete);
            return Ok();
        }

    }
}
