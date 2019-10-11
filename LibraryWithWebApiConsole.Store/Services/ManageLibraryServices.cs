using LibraryWithWebApi.Models;
using LibraryWithWebApiConsole.Store.IRepository;
using LibraryWithWebApiConsole.Store.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWithWebApiConsole.Store.Services
{
    public class ManageLibraryServices:IManageLibraryServices
    {
        /*      private IBookIssueRepository _BookIssueRepository;
                private IReturnBookRepository _ReturnBookRepository;*/
        private IReportingService _reportingService;
        private LibraryUnitOfWork _LibraryUnitOfWork;

        public ManageLibraryServices(LibraryUnitOfWork libraryUnitOfWork,IReportingService reportingService)
        {
            _LibraryUnitOfWork = libraryUnitOfWork;
            _reportingService = reportingService;  
        }

        public bool IssueBook(int Id, string Barcode)
        {
            bool IsIssued;
            try
            {
                var b = _LibraryUnitOfWork.BookIssueRepository.GetBookMatchWith(Barcode);
                _LibraryUnitOfWork.BookIssueRepository.IssueABook(Id, Barcode, b);
                _LibraryUnitOfWork.BookIssueRepository.BookCopyCountDecrement(b);
                _LibraryUnitOfWork.Save();
                IsIssued = true;
            }
            catch (Exception)
            {
                IsIssued = false;
            }
            return IsIssued;
            
        }



        public bool ReturnBook(int Id, string Barcode)
        {
            bool IsReturned;
            try
            {
                var IssueDate = _LibraryUnitOfWork.BookIssueRepository.GetBookIssueDate(Id, Barcode);
                var ReturnDate = DateTime.UtcNow;
                double LateFee = _reportingService.CalculateFine(ReturnDate, IssueDate);
                _LibraryUnitOfWork.ReturnBookRepository.ReturnBook(Id, Barcode, LateFee);
                _LibraryUnitOfWork.Save();
                IsReturned = true;
            }
            catch (Exception)
            {
                IsReturned= false;
            }
            return IsReturned;

            
        }

        
    }
}
