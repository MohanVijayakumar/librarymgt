using System.Threading.Tasks;

using lmgtdomain.Author.Repository;
using lmgtdomain.Author.Dto;
namespace lmgtpersistence.Domain.Author
{
    public class AuthorSettingsRepository : RepositoryBase , IAuthorSettingsRepository
    {
        public AuthorSettingsRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<AuthorSettingsDto> ByAsync()
        {
            return await _Db.SingleByIdAsync<AuthorSettingsDto>(1);
        }
    }
}