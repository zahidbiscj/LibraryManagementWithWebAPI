

using LibraryWithWebApiConsole.Store.IRepository;
using LibraryWithWebApiConsole.Store.IServices;
using LibraryWithWebApiConsole.Store.Repository;

namespace LibraryWithWebApiConsole.Store.Services
{
    public class LibraryUnitOfWork: ILibraryUnitOfWork
    {
        private LibraryContext _context;
        public IBookIssueRepository BookIssueRepository { get; private set; }
        public IReturnBookRepository ReturnBookRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
        public IBookRepository BookRepository { get; private set; }

       
        public LibraryUnitOfWork(string ConnectionString , string MigrationAssemblyName)
        {
            _context = new LibraryContext(ConnectionString,MigrationAssemblyName);
    
            BookIssueRepository = new BookIssueRepository(_context);
            ReturnBookRepository = new ReturnBookRepository(_context);
            BookRepository = new BookRepository(_context);
            StudentRepository = new StudentRepository(_context);
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
