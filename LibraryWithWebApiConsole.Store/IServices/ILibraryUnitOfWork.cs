using LibraryWithWebApiConsole.Store.IRepository;

namespace LibraryWithWebApiConsole.Store.IServices
{
    public interface ILibraryUnitOfWork
    {
        IBookIssueRepository BookIssueRepository { get; }
        IReturnBookRepository ReturnBookRepository { get; }
        IStudentRepository StudentRepository { get; }
        IBookRepository BookRepository { get; }

        void Save();
    }
}
