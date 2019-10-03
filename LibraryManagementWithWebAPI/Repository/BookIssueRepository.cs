using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementWithWebAPI.Models;

namespace LibraryManagementWithWebAPI.Repository
{
    public class BookIssueRepository:IBookIssueRepository
    {
        private LibraryContext _context;
        public BookIssueRepository(LibraryContext context)
        {
            _context = context;
        }

        public void IssueABook(int Id, string Barcode) {

            var b = _context.Books.Where(x => x.BarCode == Barcode).SingleOrDefault();

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
                //Copycount one decrement for issuing book because student took the book
                
                b.CopyCount -= 1;
                _context.SaveChanges();
                
            }
        }

        public DateTime GetBookIssueDate(int Id, string Barcode)
        {
             var IssueDetails =  _context.IssueBooks.Where(x => x.StudentId == Id && x.BookBarCode == Barcode).FirstOrDefault();
             return IssueDetails.IssueDate;
        }
    }
}
