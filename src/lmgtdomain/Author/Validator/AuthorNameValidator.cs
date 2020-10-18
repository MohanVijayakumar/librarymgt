using System.Threading.Tasks;

using lmgtdomain.Author.Dto;
using lmgtdomain.Author.Model;
using lmgtcommon.Validation;

namespace lmgtdomain.Author.Validator
{
    public class AuthorNameValidator : ValidatorBase,  IAuthorValidator
    {
        public AuthorInputModel InputModel {get;set;}
        public AuthorSettingsDto Settings {get;set;}

        public  override Task<bool> ValidateAsync()
        {
            if(string.IsNullOrWhiteSpace(InputModel.Name))
            {
                SystemErrorMessage = "Name is empty.Client validation failed/Bypassed";
                ExposableErrorMessage = "Name is empty";
                return Task.FromResult(false);
            }
            
            if(InputModel.Name.Length < Settings.NameMinLength)
            {   
                SystemErrorMessage = $"Length of Name is too short.Minimum length required is {Settings.NameMinLength}.Client validation Failed/Bypassed";
                ExposableErrorMessage = "Invalid Name";
                return Task.FromResult(false);
            }
            
            if(InputModel.Name.Length > Settings.NameMaxLength)
            {   
                SystemErrorMessage = $"Length of Name is too long.Maximum length is {Settings.NameMaxLength}.Client validation Failed/Bypassed";
                ExposableErrorMessage = "Invalid Name";
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }       
    }
}