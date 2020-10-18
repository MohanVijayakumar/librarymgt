using System.Threading.Tasks;

using lmgtdomain.Book.Repository;
namespace lmgtdomain.Book.Validator
{
    public class BookCategoryValidator : BookValidatorBase
    {
        public BookCategoryValidator(IBookCategoryRepository bookCategoryRepository)
        {
            _BookCategoryRepository = bookCategoryRepository;
        }
        private readonly IBookCategoryRepository _BookCategoryRepository;
        public async override Task<bool> ValidateAsync()
        {
            var bCategory = await _BookCategoryRepository.ByAsync(InputModel.CategoryID);
            if(bCategory == null)
            {
                SystemErrorMessage = $"The BookCategory not found in database.Received Book Category is {InputModel.CategoryID}.Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid Book Category";
                return false;
            }
            return true;
        } 
    }
}