
using LibraryWithWebApi.Models;
using LibraryWithWebApiConsole.Store;
using LibraryWithWebApiConsole.Store.IRepository;
using System;
using System.Linq;

namespace LibraryWithWebApiConsole.Store.Repository
{
    public class ReturnBookRepository:IReturnBookRepository
    {
        private LibraryContext _context;
        public ReturnBookRepository(LibraryContext context)
        {
            _context = context;
        }

        

        public DateTime GetBookReturnDate(int Id, string Barcode) {
           var student = _context.ReturnBooks.Where(x => x.StudentId == Id && x.BookBarCode == Barcode).FirstOrDefault();
            return student.ReturnDate;
        }

        public void ReturnBook(int Id, string Barcode,double fine) {

            var StudentUpdate = _context.Students.Where(x => x.Id == Id).SingleOrDefault();
            StudentUpdate.FineAmount += fine;
                
           
            var bookAvailable = _context.Books.Where(x => x.BarCode == Barcode).FirstOrDefault();
            bookAvailable.CopyCount += 1;

            _context.ReturnBooks.Add(new ReturnBook()
            {
                StudentId = Id,
                bookId =  bookAvailable.Id,
                BookBarCode = Barcode,
                ReturnDate = DateTime.UtcNow
            });

        }
    }
}
