using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.IRepository
{
    public interface IBookIssueRepository
    {
        Book GetBookMatchWith(string Barcode);
        void IssueABook(int Id, string Barcode,Book b);
        void BookCopyCountDecrement(Book book);
        DateTime GetBookIssueDate(int Id, string Barcode);
    }
}
