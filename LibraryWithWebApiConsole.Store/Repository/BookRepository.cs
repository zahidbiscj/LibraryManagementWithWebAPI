using LibraryWithWebApi.Models;
using LibraryWithWebApiConsole.Store;
using LibraryWithWebApiConsole.Store.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.Repository
{
    public class BookRepository: IBookRepository
    {
        LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public Book ShowBooksDetails(int Id) {
            return _context.Books.Where(x=>x.Id==Id).FirstOrDefault();
        }
        public void AddBook(Book book) {
            _context.Books.Add(new Book()
            {
                Title = book.Title,
                Author = book.Author,
                BarCode = book.BarCode,
                CopyCount = book.CopyCount,
                Edition = book.Edition
            });

            _context.SaveChanges();
        }
        public List<Book> GetAllBook() {
            return _context.Books.ToList();
        }
        public void DeleteBook(string Barcode) {
           _context.Books.Remove(_context.Books.Where(i => i.BarCode == Barcode).FirstOrDefault());
        }
        public bool UpdateBookInfo(int id, Book book) {
            var FindStudent = _context.Books.Where(i => i.Id == id).FirstOrDefault();
            
            if (FindStudent != null)
            {
                FindStudent.Author = book.Author;
                FindStudent.BarCode = book.BarCode;
                FindStudent.CopyCount = book.CopyCount;
                FindStudent.Title = book.Title;
                FindStudent.Edition = book.Edition;

                _context.SaveChanges();
                return true;
            }
            else {
                return false;
            }
            
        }


    }
}
