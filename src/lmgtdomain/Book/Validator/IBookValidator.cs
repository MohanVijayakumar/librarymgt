using lmgtcommon.Validation;

using lmgtdomain.Book.Model;
using lmgtdomain.Book.Dto;
namespace lmgtdomain.Book.Validator
{
    public interface IBookValidator : IValidator
    {
        BookInputModel InputModel {get;set;}
        BookSettingsDto Settings {get;set;}
    }
}