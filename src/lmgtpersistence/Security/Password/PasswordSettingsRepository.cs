using System.Threading.Tasks;

using lmgtsecurity.Password.Repository;
using lmgtsecurity.Password.Dto;
namespace lmgtpersistence.Security
{
    public class PasswordSettingsRepository : RepositoryBase, IPasswordSettingsRepository
    {
        public PasswordSettingsRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }
        public async Task<PasswordSettingsDto> ByAsync()
        {
            return await _Db.SingleByIdAsync<PasswordSettingsDto>(1);
        }
    }
}