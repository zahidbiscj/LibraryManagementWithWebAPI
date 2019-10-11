using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryWithWebApi.Client.WebRequestProcess;

namespace LibraryWithWebApi.Client
{
    public class EntryStudent
    {
        public void EntryStudentInfo()
        {
            Student student = new Student();
            
            Console.WriteLine("Entry Student Information center");
            Console.WriteLine("===============================");
            Console.Write("Please enter student Id: ");
            student.Id = int.Parse(Console.ReadLine());

            Console.Write("Please enter student Name: ");
            student.Name = Console.ReadLine();

            student.FineAmount = 0;
            Console.WriteLine("===============================");

            PostObject entryStudent = new PostObject();
            entryStudent.Insert(student,"Students");
           
        }



        
    }
}
