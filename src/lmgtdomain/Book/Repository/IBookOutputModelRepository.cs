using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Book.Model;
namespace lmgtdomain.Book.Repository
{
    public interface IBookOutputModelRepository
    {
        Task<List<BookOutputModel>> AllAsync();
    }
}