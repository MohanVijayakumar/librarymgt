using System.Threading.Tasks;

using lmgtdomain.Author.Dto;
namespace lmgtdomain.Author.Repository
{
    public interface IAuthorSettingsRepository
    {
        Task<AuthorSettingsDto> ByAsync();
    }
}