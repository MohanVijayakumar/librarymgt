using lmgtdomain.User.Model;
using lmgtdomain.User.Dto;
using lmgtcommon.Validation;
namespace lmgtdomain.User.Validator
{
    public interface IEditUserValidator : IValidator
    {
        EditUserInputModel InputModel {get;set;}
        UserSettingsDto Settings {get;set;}
    }
}