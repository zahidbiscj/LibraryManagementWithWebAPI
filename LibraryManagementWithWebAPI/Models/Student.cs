using LibraryManagementWithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementWithWebAPI
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double FineAmount { get; set; }
        public IList<IssueBook> BookIssues { get; set; }
        public IList<ReturnBook> BookReturns { get; set; }

    }
}
