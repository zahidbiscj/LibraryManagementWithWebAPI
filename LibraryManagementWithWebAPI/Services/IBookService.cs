using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Services
{
    public interface IBookService
    {
        List<Book> ShowAllBooks();
        Book GetBooksDetails(int Id);
        void EntryBook(Book book);
        void RemoveBook(string Barcode);
        bool UpdateBookInfo(int id, Book book);
    }
}
