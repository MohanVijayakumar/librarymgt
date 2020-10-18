using System.Threading.Tasks;

using lmgtdomain.User.Dto;
namespace lmgtdomain.User.Repository
{
    public interface IUserSettingsRepository
    {
        Task<UserSettingsDto> ByAsync();
    }
}