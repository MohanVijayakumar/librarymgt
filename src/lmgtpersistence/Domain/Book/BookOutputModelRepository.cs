using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<BookOutputModel> ByAsync(int bookID)
        {
            string q = @"SELECT * FROM ""GetBookOutputModelByID""(@0);";
            object[] args =  new object[] { bookID};
            return (await _DbWrapper.ReturnProcAsync<BookOutputModel>(q,args)).FirstOrDefault();
        }

        public async Task<List<BookOutputModel>> ByAuthorAsync(int authorID)
        {
            string q = @"SELECT * FROM ""GetBookOutputModelByAuthor""(@0);";
            object[] args =  new object[] { authorID};
            return (await _DbWrapper.ReturnProcAsync<BookOutputModel>(q,args));
        }
    }
}