using System.Threading.Tasks;

using lmgtdomain.Publisher.Repository;
namespace lmgtusecase.Publisher
{
    public class DeletePublisher
    {
        public DeletePublisher(IPublisherRepository publisherRepository)
        {
            _PublisherRepository = publisherRepository;
        }
        private readonly IPublisherRepository _PublisherRepository;
        public async Task<bool> DeleteAsync(int publisherID)
        {
            var countDelete = await _PublisherRepository.DeleteAsync(publisherID);
            return countDelete == 1;
        }
    }
}