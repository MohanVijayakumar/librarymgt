using System;
using System.Threading.Tasks;

using lmgtcommon.Validation;
using lmgtdomain.User.Dto;
using lmgtdomain.User.Model;
namespace lmgtdomain.User.Validator
{
    public abstract class UserValidatorBase : ValidatorBase,IUserValidator
    {
        public UserInputModel InputModel {get;set;}
        public UserSettingsDto Settings {get;set;}
        public abstract override Task<bool> ValidateAsync();
        protected void _ValidateArgs()
        {
            if(InputModel == null)
            {
                throw new ArgumentNullException("The InputModel is null");                               
            }

            if(Settings == null)
            {
                throw new ArgumentNullException("The Settings is null");
            }
        }
    }
}