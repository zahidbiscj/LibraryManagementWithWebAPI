using LibraryWithWebApi.Models;
using LibraryWithWebApiConsole.Store.IRepository;
using LibraryWithWebApiConsole.Store.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.Services
{
    public class BookService:IBookService
    {
        private IBookRepository _BookRepository;

        public BookService(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }

       public  List<Book> ShowAllBooks() {
            return _BookRepository.GetAllBook();
        }
        public Book GetBooksDetails(int Id) {
            return _BookRepository.ShowBooksDetails(Id);
        }
        public bool EntryBook(Book book) {
            bool IsAdded;
            try
            {
                _BookRepository.AddBook(book);
                IsAdded = true;
            }
            catch (Exception)
            {
                IsAdded = false;
            }
            return IsAdded;
           
        }
        public void RemoveBook(string Barcode) {
            _BookRepository.DeleteBook(Barcode);
        }
        public bool UpdateBookInfo(int id, Book book) {
            return _BookRepository.UpdateBookInfo(id,book);
        }
    }
}
