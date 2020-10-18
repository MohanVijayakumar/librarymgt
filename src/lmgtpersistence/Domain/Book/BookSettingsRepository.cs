using System.Threading.Tasks;

using lmgtdomain.Book.Repository;
using lmgtdomain.Book.Dto;
namespace lmgtpersistence.Domain.Book
{
    public class BookSettingsRepository : RepositoryBase ,IBookSettingsRepository
    {
        public BookSettingsRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {
            
        }

        public async Task<BookSettingsDto> ByAsync()
        {
            return await _Db.SingleByIdAsync<BookSettingsDto>(1);
        }
    }
}