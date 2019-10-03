using LibraryManagementWithWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementWithWebAPI.Services
{
    public class ManageLibraryServices:IManageLibraryServices
    {
        private IBookIssueRepository _BookIssueRepository;
        private IReturnBookRepository _ReturnBookRepository;
        private IReportingService _reportingService;
        public ManageLibraryServices(IBookIssueRepository bookIssueRepository, IReturnBookRepository returnBookRepository, IReportingService reportingService)
        {
            _BookIssueRepository = bookIssueRepository;
            _ReturnBookRepository = returnBookRepository;
            _reportingService = reportingService;
        }

        public void IssueBook(int Id, string Barcode)
        {
            _BookIssueRepository.IssueABook(Id, Barcode);
        }

        public void ReturnBook(int Id, string Barcode)
        {
            var IssueDate = _BookIssueRepository.GetBookIssueDate(Id,Barcode);
            var ReturnDate = DateTime.UtcNow;
            double LateFee = _reportingService.CalculateFine(ReturnDate,IssueDate);
            _ReturnBookRepository.ReturnBook(Id, Barcode, LateFee);
        }

        
    }
}
