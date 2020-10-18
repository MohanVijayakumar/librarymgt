using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Book.Model;
using lmgtdomain.Book.Repository;
namespace lmgtpersistence.Domain.Book
{
    public class BookOutputModelRepository : RepositoryBase,IBookOutputModelRepository
    {
        public BookOutputModelRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<List<BookOutputModel>> AllAsync()
        {
            string q = @"SELECT * FROM ""GetAllBookOutputModel""();";
            return await _DbWrapper.ReturnProcAsync<BookOutputModel>(q);
        }
    }
}