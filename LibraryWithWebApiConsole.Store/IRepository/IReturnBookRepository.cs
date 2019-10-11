using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.IRepository
{
    public interface IReturnBookRepository
    {
        DateTime GetBookReturnDate(int Id, string Barcode);

        void ReturnBook(int Id, string Barcode, double fine);

    }
}
