using System.Threading.Tasks;

using lmgtdomain.Book.Repository;
namespace lmgtdomain.Book.Validator
{
    public class LendBookBookValidator : LendBookValidatorBase
    {
        public LendBookBookValidator(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }
        private readonly IBookRepository _BookRepository;
        public async override Task<bool> ValidateAsync()
        {            
            Context.BookToBeLend = await _BookRepository.ByAsync(Context.InputModel.BookID);
            if(Context.BookToBeLend == null)
            {
                SystemErrorMessage = $"The book not found in database.received book id is {Context.InputModel.BookID}.Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid Book";
                return false;
            }
            return true;
        }
    }
}