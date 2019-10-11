using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWithWebApi.Models;
using LibraryWithWebApiConsole.Store.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_6_LibraryWithWebApiConsole.Controllers
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
        public ActionResult IssueBook([FromBody] IssueBook BookIssue)/// StudentID,Barcode 
        {
            try
            {
                var IsIssued = _ManageLibraryServices.IssueBook(BookIssue.StudentId , BookIssue.BookBarCode);
           
                if (IsIssued) { return Ok("Book Issued Successfully"); }
                else { return NotFound("Failed to Issue Book"); }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/api/ManagingLibrary/ReturnBook")]
        public ActionResult ReturnBook([FromBody] ReturnBook BookReturn)/// StudentID,Barcode 
        {
            try
            {
                var IsReturned = _ManageLibraryServices.ReturnBook(BookReturn.StudentId, BookReturn.BookBarCode);

                if (IsReturned) { return Ok("Book Returned Successfully"); }
                else { return NotFound("Failed to Return book"); }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


    }
}