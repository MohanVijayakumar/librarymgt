using System.Threading.Tasks;

using lmgtdomain.Book.Dto;
namespace lmgtdomain.Book.Repository
{
    public interface IBookSettingsRepository
    {
        Task<BookSettingsDto> ByAsync();
    }
}
