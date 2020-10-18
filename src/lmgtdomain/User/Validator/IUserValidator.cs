using lmgtdomain.User.Dto;
using lmgtdomain.User.Model;

using lmgtcommon.Validation;
namespace lmgtdomain.User.Validator
{
    public interface IUserValidator  : IValidator
    {
        UserInputModel InputModel {get;set;}
        UserSettingsDto Settings {get;set;}
    }
}