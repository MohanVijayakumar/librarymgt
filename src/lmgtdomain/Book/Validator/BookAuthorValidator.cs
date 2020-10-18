using System.Threading.Tasks;

using lmgtdomain.Author.Repository;
namespace lmgtdomain.Book.Validator
{
    public class BookAuthorValidator : BookValidatorBase
    {
        public BookAuthorValidator(IAuthorRepository authorRepository)
        {
            _AuthorRepository = authorRepository;
        }
        private readonly  IAuthorRepository _AuthorRepository;
        public  async override Task<bool> ValidateAsync()
        {
            
            var author = await _AuthorRepository.ByAsync(InputModel.AuthodID);
            if(author == null)
            {
                SystemErrorMessage = "Author not found in database.Client validation failed/Bypassed";
                ExposableErrorMessage = "Invalid Author";
                return false;
            }
            return true;
        }
    }
}