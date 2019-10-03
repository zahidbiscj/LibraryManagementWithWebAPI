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
    public class ManagingLibraryController : ControllerBase
    {
        private IManageLibraryServices _ManageLibraryServices;
        public ManagingLibraryController(IManageLibraryServices ManageLibraryServices)
        {
            _ManageLibraryServices = ManageLibraryServices;
        }

        [HttpPost("/api/ManagingLibrary/IssueBook")]
        public void IssueBook([FromBody]string[] values)/// StudentID,Barcode 
        {
            _ManageLibraryServices.IssueBook(int.Parse(values[0]), values[1]);

        }

        [HttpPost("/api/ManagingLibrary/ReturnBook")]
        public void ReturnBook([FromBody] string[] values)/// StudentID,Barcode 
        {
            _ManageLibraryServices.ReturnBook(int.Parse(values[0]), values[1]);
        }


    }
}