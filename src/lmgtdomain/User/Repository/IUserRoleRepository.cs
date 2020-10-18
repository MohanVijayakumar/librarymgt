using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.User.Dto;
namespace lmgtdomain.User.Repository
{
    public interface IUserRoleRepository
    {
        Task<UserRoleDto> ByAsync(int iD);
        Task<List<UserRoleDto>> AllAsync();
        
    }
}