using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LibraryWithWebApi.Client
{
    class Program
    {

        static void Main(string[] args)
        {

        label:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t=================================================================================");
            Console.WriteLine("\t\t\t\tWelcome to library system.");

            Console.WriteLine("\t\t\t\tTo entry student information enter: 1");
            Console.WriteLine("\t\t\t\tTo entry book information enter: 2");
            Console.WriteLine("\t\t\t\tTo issue a book, enter: 3");
            Console.WriteLine("\t\t\t\tTo return a book enter: 4");
            Console.WriteLine("\t\t\t\tTo check fine, enter: 5 ");
            Console.WriteLine("\t\t\t\tTo receive fine, enter: 6");
            Console.WriteLine("\t=================================================================================");
            try
            {
                Console.Write("\n\n\nPlease enter your choice: ");
                int ch = int.Parse(Console.ReadLine());
            

                Console.WriteLine("=================================");

                switch (ch)
                {


                    case 1:
                        new EntryStudent().EntryStudentInfo();
                        break;

                    case 2:
                        new BookEntry().EntryBookInfo();
                        break;

                    case 3:
                       new BookIssue().IssueBook();
                        break;

                    case 4:
                        new BookReturn().ReturnBook();
                        break;

                    case 5:
                        new FineCheck().CheckFine();
                        break;
                    case 6:
                        new ReceiveFine().FineReceive();
                        break;

                    default:
                        Console.WriteLine("Invalid Key Given. Please Try Again");
                        break;
                }

            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            Console.WriteLine("Please Enter any key to Continue......");
            Console.ReadKey();

            goto label;
            }
  
    }
    
}
