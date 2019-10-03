using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Services
{
    public interface IManageLibraryServices
    {
        void IssueBook(int Id, string Barcode);
        void ReturnBook(int Id, string Barcode);
    }
}
