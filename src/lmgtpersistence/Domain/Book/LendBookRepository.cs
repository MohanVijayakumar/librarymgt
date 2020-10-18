using System.Threading.Tasks;

using lmgtdomain.Book.Repository;
using lmgtdomain.Book.Dto;
namespace lmgtpersistence.Domain.Book
{
    public class LendBookRepository : RepositoryBase,ILendBookRepository
    {
        public LendBookRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<LendBookDto> AddAsync(LendBookDto lendBook)
        {
            await _Db.InsertAsync<LendBookDto>(lendBook);
            return lendBook;
        }
    }
}