using System.Threading.Tasks;

using lmgtdomain.User.Repository;
using lmgtdomain.User.Dto;
namespace lmgtpersistence.Domain.User
{
    public class UserRepository : RepositoryBase,IUserRepository
    {
        public UserRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<UserDto> AddAsync(UserDto user)
        {
            await _Db.InsertAsync<UserDto>(user);
            return user;
        }
        public async Task<UserDto> ByAsync(int iD)
        {
            return await _Db.SingleOrDefaultByIdAsync<UserDto>(iD);
        }
        public async Task<UserDto> ByNameAsync(string name)
        {
            return await _Db.Query<UserDto>().Where(w=> w.Name.ToLower() == name.ToLower()).SingleOrDefaultAsync();
        }
        public async Task<int> DeleteAsync(int iD)
        {
            return await _Db.DeleteMany<UserDto>().Where(w=> w.ID == iD).ExecuteAsync();
        }

        public async Task<int> UpdateAtEditAsync(UserDto user)
        {
            return await _Db.UpdateAsync<UserDto>(user,(u) => new {
                u.Name,
                u.RoleID
            });
        }
    }
}