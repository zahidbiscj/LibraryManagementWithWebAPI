using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.IServices
{
    public interface IManageLibraryServices
    {
       
        bool IssueBook(int Id, string Barcode);
        bool ReturnBook(int Id, string Barcode);
    }
}
