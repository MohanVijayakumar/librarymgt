using System.Threading.Tasks;

using lmgtdomain.User.Dto;
namespace lmgtdomain.User.Repository
{
    public interface IUserRepository
    {
        Task<UserDto> AddAsync(UserDto user);
        Task<UserDto> ByAsync(int iD);
        Task<UserDto> ByNameAsync(string name);
        Task<int> DeleteAsync(int iD);

        Task<int> UpdateAtEditAsync(UserDto user);
    }
}