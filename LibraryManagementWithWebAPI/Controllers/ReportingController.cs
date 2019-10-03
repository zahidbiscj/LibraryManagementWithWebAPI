using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementWithWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWithWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private IReportingService _reportingService;
        public ReportingController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpPost]
        public ActionResult<double> CheckFineForEachBook([FromBody] string[] values)//Id,Barcode
        {
            return _reportingService.CheckLateFee(int.Parse(values[0]),values[1]);
        }

        [HttpGet("{id}")]
        public ActionResult<double> StudentCheckFine(int Id)
        {
            return _reportingService.CheckFine(Id);
        }


    }
}