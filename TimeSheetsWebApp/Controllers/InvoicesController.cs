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
    [Route("api/timesheets/invoices")]

    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepo _repository;

        public InvoicesController(IInvoiceRepo repository)
        {
            _repository = repository;
        }


        [HttpGet("read")]
        public IActionResult GetListInvoices()
        {
            _repository.GetList();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateInvoice([FromQuery] Invoices input)
        {
            _repository.Create(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateClient([FromQuery] Invoices invoice, [FromQuery] Invoices invoiceToUpdate)
        {
            _repository.Update(invoice, invoiceToUpdate);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteClient([FromQuery] Invoices invoicesToDelete)
        {
            _repository.Delete(invoicesToDelete);
            return Ok();
        }

    }
}
