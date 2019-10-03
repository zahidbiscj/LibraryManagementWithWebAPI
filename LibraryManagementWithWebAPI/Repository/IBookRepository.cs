using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Repository
{
    public interface IBookRepository
    {
        Book ShowBooksDetails(int Id);
        void AddBook(Book book);
        List<Book> GetAllBook();
        void DeleteBook(string Barcode);
        bool UpdateBookInfo(int id, Book book);
    }
}
