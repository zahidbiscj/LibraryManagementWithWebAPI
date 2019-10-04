using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementWithWebAPI.Models;
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
        public void IssueBook([FromBody] IssueBook BookIssue)/// StudentID,Barcode 
        {
            _ManageLibraryServices.IssueBook(BookIssue.StudentId , BookIssue.BookBarCode);

        }

        [HttpPost("/api/ManagingLibrary/ReturnBook")]
        public void ReturnBook([FromBody] ReturnBook BookReturn)/// StudentID,Barcode 
        {
            _ManageLibraryServices.ReturnBook(BookReturn.StudentId,BookReturn.BookBarCode);
        }


    }
}