using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApi.Models
{
    public class IssueBook
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public string BookBarCode { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
