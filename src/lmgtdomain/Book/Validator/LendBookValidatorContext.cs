using lmgtdomain.Book.Model;
using lmgtdomain.Book.Dto;
namespace lmgtdomain.Book.Validator
{
    public class LendBookValidatorContext
    {
        public LendBookInputModel InputModel {get;set;}
        public BookDto BookToBeLend {get;set;}
    }
}