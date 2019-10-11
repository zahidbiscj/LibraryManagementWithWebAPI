using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWithWebApi.Models;
using LibraryWithWebApiConsole.Store;
using LibraryWithWebApiConsole.Store.IRepository;

namespace LibraryWithWebApiConsole.Store.Repository
{
    public class BookIssueRepository:IBookIssueRepository
    {
        private LibraryContext _context;
        public BookIssueRepository(LibraryContext context)
        {
            _context = context;
        }

        public void IssueABook(int Id, string Barcode,Book b) {

           
            if (_context.Students.Any(db => db.Id == Id) &&
                _context.Books.Any(db => db.BarCode == Barcode) &&
                _context.Books.Any(db => db.CopyCount >= 0))
            {

                _context.IssueBooks.Add(new IssueBook()
                {
                    StudentId = Id,
                    BookBarCode = Barcode,
                    bookId = b.Id,
                    IssueDate = DateTime.UtcNow
                });
                 
            }
        }

        public DateTime GetBookIssueDate(int Id, string Barcode)
        {
             var IssueDetails =  _context.IssueBooks.Where(x => x.StudentId == Id && x.BookBarCode == Barcode).FirstOrDefault();
             return IssueDetails.IssueDate;
        }

        public Book GetBookMatchWith(string Barcode)
        {
            return  _context.Books.Where(x => x.BarCode == Barcode).SingleOrDefault();
            
        }

        public void BookCopyCountDecrement(Book book)
        {
            book.CopyCount -= 1;
        }

        
    }


}
