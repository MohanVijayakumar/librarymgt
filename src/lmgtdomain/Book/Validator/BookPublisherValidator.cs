using System.Threading.Tasks;

using lmgtdomain.Publisher.Repository;
namespace lmgtdomain.Book.Validator
{
    public class BookPublisherValidator : BookValidatorBase
    {
        public BookPublisherValidator(IPublisherRepository publisherRepository)
        {
            _PublisherRepository = publisherRepository;
        }
        private readonly  IPublisherRepository _PublisherRepository;
        public  async override Task<bool> ValidateAsync()
        {
            
            var publisher = await _PublisherRepository.ByAsync(InputModel.PublisherID);
            if(publisher == null)
            {
                SystemErrorMessage = "publisher not found in database.Client validation failed/Bypassed";
                ExposableErrorMessage = "Invalid publisher";
                return false;
            }
            return true;
        }
    }
}