
using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.IServices
{
    public interface IBookService
    {
        List<Book> ShowAllBooks();
        Book GetBooksDetails(int Id);
        bool EntryBook(Book book);
        void RemoveBook(string Barcode);
        bool UpdateBookInfo(int id, Book book);
    }
}
