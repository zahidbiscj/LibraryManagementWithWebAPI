using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Repository
{
    public interface IStudentRepository
    {
        Student ShowMembershipProfile(int Id);
        void EnrollStudent(int id, string name);
        List<Student> GetAllStudent();
        void DeleteStudentInfo(int id);
        bool UpdateStudentInfo(int id, Student student);
        bool ReceiveFineAmount(int Id, double fineAmount);
        double CheckFine(int Id);


    }
}
