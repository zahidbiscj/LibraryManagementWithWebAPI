using LibraryWithWebApi.Client.WebRequestProcess;
using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWithWebApi.Client
{
    public class BookIssue
    {
        public  void IssueBook()
        {
            IssueBook bookIssue = new IssueBook();
            
            Console.WriteLine("Issue a book to student");
            Console.WriteLine("===============================");
            Console.Write("Please Enter Student Id : ");
            bookIssue.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Please Enter Book Barcode : ");
            bookIssue.BookBarCode = Console.ReadLine();
            Console.WriteLine("===============================");

            PostObject IssueBook = new PostObject();
            IssueBook.Insert(bookIssue, "ManagingLibrary/IssueBook");

        }
        
    }
}
