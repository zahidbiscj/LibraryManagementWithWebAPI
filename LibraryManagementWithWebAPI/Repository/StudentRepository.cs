using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementWithWebAPI.Models;

namespace LibraryManagementWithWebAPI.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private LibraryContext _context;
        public StudentRepository(LibraryContext context) {
            _context = context;
        }

        public List<Student> GetAllStudent() {
            return _context.Students.ToList();
        }

       public Student ShowMembershipProfile(int Id)
        {
            return _context.Students.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void EnrollStudent(int id , string name) {
            
                _context.Students.Add(new Student
                {
                    Id = id,
                    Name = name
                });
                _context.SaveChanges();
            
        }

        public bool UpdateStudentInfo(int id , Student student)
        {
            var targetStudent = _context.Students.Where(x => x.Id == id).FirstOrDefault();

            if (targetStudent != null)
            {
                targetStudent.Id = student.Id;
                targetStudent.Name = student.Name;
                targetStudent.FineAmount = student.FineAmount;

                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public void DeleteStudentInfo(int id)
        {
            var readStudent = _context.Students.Where(x => x.Id == id).FirstOrDefault();

            _context.Students.Remove(readStudent);

            _context.SaveChanges();
        }

        public bool ReceiveFineAmount(int Id, double fineAmount)
        {
            var CheckFine = _context.Students.Where(x => x.Id == Id).SingleOrDefault();

            var RemainingFineBalance = CheckFine.FineAmount - fineAmount;

            if (RemainingFineBalance < 0) { return false; }

            else
            {
                CheckFine.FineAmount = RemainingFineBalance;
                _context.SaveChanges();
                return true;
            }
            
        }

        public double CheckFine(int Id) {
            var student = _context.Students.Where(x=> x.Id == Id).FirstOrDefault();
            return student.FineAmount;
            
        }
    }

    
}
