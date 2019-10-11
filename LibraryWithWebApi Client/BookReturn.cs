using LibraryWithWebApi.Client.WebRequestProcess;
using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWithWebApi.Client
{
    public class BookReturn
    {
        public void ReturnBook() {
            ReturnBook bookReturn = new ReturnBook();

            Console.WriteLine("Return a book ");
            Console.WriteLine("===============================");
            Console.Write("Please Enter Student Id : ");
            bookReturn.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Please Enter Book Barcode : ");
            bookReturn.BookBarCode = Console.ReadLine();

            PostObject postObject = new PostObject();
            postObject.Insert(bookReturn, "ManagingLibrary/ReturnBook");
        }
    }
}
