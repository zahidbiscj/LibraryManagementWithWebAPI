using LibraryWithWebApi.Client.WebRequestProcess;
using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWithWebApi.Client
{
    public class FineCheck
    {
        public  void CheckFine()
        {
            Student student = new Student();

            Console.WriteLine("Check Fine");
            Console.WriteLine("===============================");

            Console.Write("Please Enter Student Id : ");
            student.Id = int.Parse(Console.ReadLine());

            CheckFine check = new CheckFine();
            Console.WriteLine("Your total Fine is = "+check.GetFine(student.Id));

        }       
    }
}
