using LibraryWithWebApi.Models;
using LibraryWithWebApiConsole.Store.IRepository;
using LibraryWithWebApiConsole.Store.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.Services
{
    public class MembershipService:IMembershipService
    {
        private IStudentRepository _studentRepository; 
        public MembershipService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<Student> ShowAllStudent() {
           return  _studentRepository.GetAllStudent();
        }
        public bool EnrollMembership(int id,string name) {
            bool Isenrolled;
            try
            {
                _studentRepository.EnrollStudent(id, name);
                 Isenrolled = true;
            }
            catch (Exception)
            {
                Isenrolled = false;
            }
            return Isenrolled;
             
        }

        public Student ShowMemberProfile(int id) {
            return _studentRepository.ShowMembershipProfile(id);
        }

        public bool UpdateProfile(int id , Student student) {
            return _studentRepository.UpdateStudentInfo(id, student);
        }

        public void DeleteStudent(int id) {
            _studentRepository.DeleteStudentInfo(id);
        }

        public bool ReceiveFine(int Id, double FineAmount)
        {
            return _studentRepository.ReceiveFineAmount(Id, FineAmount);
        }

    }
}
