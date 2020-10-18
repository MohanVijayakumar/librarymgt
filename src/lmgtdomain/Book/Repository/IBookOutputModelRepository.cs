using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Book.Model;
namespace lmgtdomain.Book.Repository
{
    public interface IBookOutputModelRepository
    {
        Task<List<BookOutputModel>> AllAsync();

        Task<BookOutputModel> ByAsync(int bookID);

        Task<List<BookOutputModel>> ByAuthorAsync(int authorID);
    }
}