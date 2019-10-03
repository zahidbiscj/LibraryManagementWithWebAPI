using LibraryManagementWithWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Services
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
        public void EntryBook(Book book) {
            _BookRepository.AddBook(book);
        }
        public void RemoveBook(string Barcode) {
            _BookRepository.DeleteBook(Barcode);
        }
        public bool UpdateBookInfo(int id, Book book) {
            return _BookRepository.UpdateBookInfo(id,book);
        }
    }
}
