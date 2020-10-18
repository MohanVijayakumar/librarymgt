using lmgtcommon.Validation;
using lmgtdomain.Author.Model;
using lmgtdomain.Author.Dto;
namespace lmgtdomain.Author.Validator
{
    public interface IAuthorValidator : IValidator
    {
        AuthorInputModel InputModel {get;set;}
        AuthorSettingsDto Settings {get;set;}
    }
}