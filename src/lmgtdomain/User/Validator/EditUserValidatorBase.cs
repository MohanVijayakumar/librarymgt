using System.Threading.Tasks;

using lmgtdomain.User.Model;
using lmgtdomain.User.Dto;
using lmgtcommon.Validation;
namespace lmgtdomain.User.Validator
{
    public abstract class EditUserValidatorBase :ValidatorBase,   IEditUserValidator
    {
        public EditUserInputModel InputModel {get;set;}
        public UserSettingsDto Settings {get;set;}

        public abstract override Task<bool> ValidateAsync();
    }
}