using LibraryWithWebApi.Client.WebRequestProcess;
using LibraryWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWithWebApi.Client
{
    public class ReceiveFine
    {
        public void FineReceive() {

            Student student = new Student();
            Console.WriteLine("Receive the Fine");
            Console.WriteLine("===============================");

            Console.Write("Please Enter Student Id : ");
            student.Id = int.Parse(Console.ReadLine());


            Console.Write("Please Enter Fine amount You want to pay : ");
            student.FineAmount = double.Parse(Console.ReadLine());

            PUTObject updateObject = new PUTObject();
            updateObject.Update(student, "Students/ReceiveFine");
        }
    }
}
