using System.Threading.Tasks;

using lmgtdomain.Book.Dto;
namespace lmgtdomain.Book.Repository
{
    public interface IBookRepository
    {
        Task<BookDto> AddAsync(BookDto book);

        Task<BookDto> ByNameAsync(string name);
        Task<BookDto> ByAsync(int iD);

        Task<int> DeleteAsync(int iD);

        Task<int> UpdateAsync(BookDto book);

        Task<int> UpdateCoverImageAsync(BookDto book);

        Task<int> UpdateLendAsync(BookDto book);
    }
}
