using LibraryManagementWithWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Services
{
    public class ReportingService:IReportingService
    {
        private IStudentRepository _StudentRepository;
        private IBookIssueRepository _BookIssueRepository;
        private IReturnBookRepository _ReturnBookRepository;
        
        public ReportingService(IStudentRepository studentRepository, IBookIssueRepository BookIssueRepository, IReturnBookRepository ReturnBookRepository)
        {
            _StudentRepository = studentRepository;
            _BookIssueRepository = BookIssueRepository;
            _ReturnBookRepository = ReturnBookRepository;
        }

        public int CalculateFine(DateTime ReturnDate,DateTime IssueDate) {
            int DayCount = ((ReturnDate - IssueDate).Days) - 1;
            int WeekDays = 7;

            if (DayCount > WeekDays)
            {
                int daysDelay = DayCount - WeekDays;
                int fine = daysDelay * 10;

                return fine;
            }
            else { return 0; }
        }

        public int CheckLateFee(int id , string Barcode) {
            var IssueDate = _BookIssueRepository.GetBookIssueDate(id,Barcode);
            var ReturnDate = _ReturnBookRepository.GetBookReturnDate(id, Barcode);

           var fine = CalculateFine(ReturnDate,IssueDate);
           return fine;
        }

        public double CheckFine(int Id) {
            return _StudentRepository.CheckFine(Id);
        }
    }
}
