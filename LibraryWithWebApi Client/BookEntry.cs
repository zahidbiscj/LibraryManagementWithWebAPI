using LibraryWithWebApi.Client.WebRequestProcess;
using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWithWebApi.Client
{
   public  class BookEntry
    {
        public void EntryBookInfo()
        {
            Book book = new Book();

            Console.WriteLine("Entry Book Information Center");
            Console.WriteLine("===============================");
            Console.Write("Please enter Book Title: ");
            book.Title = Console.ReadLine();

            Console.Write("Please enter Book Author: ");
            book.Author = Console.ReadLine();

            Console.Write("Please enter Book Edition: ");
            book.Edition = Console.ReadLine();

            Console.Write("Please enter Barcode of the book: ");
            book.BarCode = Console.ReadLine();

            Console.Write("Please enter Copy Count of the book: ");
            book.CopyCount = int.Parse(Console.ReadLine());
            Console.WriteLine("===============================");

            PostObject BookEntry = new PostObject();
            BookEntry.Insert(book,"Books");
           
            
        }
    }
}
