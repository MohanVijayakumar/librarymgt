using System.Threading.Tasks;

using lmgtsecurity.Password.Dto;
namespace lmgtsecurity.Password.Repository
{
    public interface IPasswordSettingsRepository
    {
        Task<PasswordSettingsDto> ByAsync();        
    }
}