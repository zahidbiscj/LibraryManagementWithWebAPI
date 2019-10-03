using LibraryManagementWithWebAPI.Models;
using System;
using System.Linq;

namespace LibraryManagementWithWebAPI.Repository
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
            _context.SaveChanges();
                
           
            var bookAvailable = _context.Books.Where(x => x.BarCode == Barcode).FirstOrDefault();
            bookAvailable.CopyCount += 1;
            _context.SaveChanges();

            _context.ReturnBooks.Add(new ReturnBook()
            {
                StudentId = Id,
                bookId =  bookAvailable.Id,
                BookBarCode = Barcode,
                ReturnDate = DateTime.UtcNow
            });

            _context.SaveChanges();
        }
    }
}
