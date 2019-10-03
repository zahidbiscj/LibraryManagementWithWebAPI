using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementWithWebAPI;
using LibraryManagementWithWebAPI.Services;


namespace LibraryManagementWithWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _BookService;

        public BooksController(IBookService bookService)
        {
            _BookService = bookService;
        }

        // GET api/Books
        [HttpGet]
        public ActionResult<IList<Book>> Get()
        {
            return _BookService.ShowAllBooks();
        }

        // GET api/Books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return _BookService.GetBooksDetails(id);
        }

        // POST api/Books
        [HttpPost]
        public ActionResult Post([FromBody] Book books)
        {
            try
            {
                _BookService.EntryBook(books);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }



        // PUT api/Students/UpdateStudent
        [HttpPut("/api/Students/UpdateStudent/{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {

            try
            {
                bool IsUpdated = _BookService.UpdateBookInfo(id,book);
                if (IsUpdated)
                {
                    return Ok("Updated Successfully");
                }
                else
                {
                    return NotFound("ID = " + id + " Not found");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/Books/DeleteBooks/5
        [HttpDelete("/api/Books/DeleteBooks/{Barcode}")]
        public ActionResult Delete(string Barcode)
        {
            try
            {
                _BookService.RemoveBook(Barcode);
                return Ok("Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
