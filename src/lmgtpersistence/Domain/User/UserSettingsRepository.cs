using System.Threading.Tasks;

using lmgtdomain.User.Repository;
using lmgtdomain.User.Dto;
namespace lmgtpersistence.Domain.User
{
    public class UserSettingsRepository : RepositoryBase,IUserSettingsRepository
    {
        public UserSettingsRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<UserSettingsDto> ByAsync()
        {
            return await _Db.SingleByIdAsync<UserSettingsDto>(1);
        }
    }
}
