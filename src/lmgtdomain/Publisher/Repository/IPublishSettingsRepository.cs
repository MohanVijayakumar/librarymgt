using System.Threading.Tasks;

using lmgtdomain.Publisher.Dto;

namespace lmgtdomain.Publisher.Repository
{
    public interface IPublishSettingsRepository
    {
        Task<PublisherSettingsDto> ByAsync();
    }
}