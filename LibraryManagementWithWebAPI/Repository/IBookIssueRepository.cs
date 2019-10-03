using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Repository
{
    public interface IBookIssueRepository
    {
        void IssueABook(int Id, string Barcode);
        DateTime GetBookIssueDate(int Id, string Barcode);
    }
}
