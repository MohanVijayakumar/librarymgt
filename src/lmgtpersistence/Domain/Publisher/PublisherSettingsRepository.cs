using System.Threading.Tasks;

using lmgtdomain.Publisher.Repository;
using lmgtdomain.Publisher.Dto;
namespace lmgtpersistence.Domain.Publisher
{
    public class PublisherSettingsRepository : RepositoryBase,IPublishSettingsRepository
    {
        public PublisherSettingsRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<PublisherSettingsDto> ByAsync()
        {
            return await _Db.SingleByIdAsync<PublisherSettingsDto>(1);
        }
    }
}
