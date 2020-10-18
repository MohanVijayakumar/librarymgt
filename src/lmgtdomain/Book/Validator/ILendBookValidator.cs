using lmgtcommon.Validation;

using lmgtdomain.Book.Model;
namespace lmgtdomain.Book.Validator
{
    public interface ILendBookValidator : IValidator
    {
        LendBookValidatorContext Context {get;set;}
        
    }
}