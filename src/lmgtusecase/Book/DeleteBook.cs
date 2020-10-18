using System.Threading.Tasks;

using lmgtdomain.Book.Repository;
namespace lmgtusecase.Book
{
    public class DeleteBook
    {
        public DeleteBook(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }

        private readonly IBookRepository _BookRepository;
        public async Task<bool> DeleteAsync(int bookID)
        {
            return (await _BookRepository.DeleteAsync(bookID)) ==1 ;
        }
    }
}