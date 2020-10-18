using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.User.Repository;
using lmgtdomain.User.Dto;
namespace lmgtpersistence.Domain.User
{
    public class UserRoleRepository : RepositoryBase,IUserRoleRepository
    {
        public UserRoleRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<UserRoleDto> ByAsync(int iD)
        {
            return await _Db.SingleOrDefaultByIdAsync<UserRoleDto>(iD);
        }
        public async Task<List<UserRoleDto>> AllAsync()
        {
            return await _Db.Query<UserRoleDto>().ToListAsync();
        }
    }
}