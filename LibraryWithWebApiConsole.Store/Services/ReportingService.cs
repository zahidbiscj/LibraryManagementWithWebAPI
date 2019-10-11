using LibraryWithWebApiConsole.Store.IRepository;
using LibraryWithWebApiConsole.Store.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.Services
{
    public class ReportingService:IReportingService
    {
        /*private IStudentRepository _StudentRepository;
        private IBookIssueRepository _BookIssueRepository;
        private IReturnBookRepository _ReturnBookRepository;*/

        private LibraryUnitOfWork _LibraryUnitOfWork;
        
        public ReportingService(LibraryUnitOfWork libraryUnitOfWork)
        {
            _LibraryUnitOfWork = libraryUnitOfWork;
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
            var IssueDate = _LibraryUnitOfWork.BookIssueRepository.GetBookIssueDate(id, Barcode);
            var ReturnDate = _LibraryUnitOfWork.ReturnBookRepository.GetBookReturnDate(id, Barcode);
           var fine = CalculateFine(ReturnDate,IssueDate);
           return fine;
        }

        public double CheckFine(int Id) {
            return _LibraryUnitOfWork.StudentRepository.CheckFine(Id);
        }
    }
}
