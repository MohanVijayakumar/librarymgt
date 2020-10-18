using System.Threading.Tasks;

namespace lmgtdomain.User.Validator
{
    public class UserNameValidator : UserValidatorBase
    {
        public override Task<bool> ValidateAsync()
        {
            _ValidateArgs();
            if(string.IsNullOrWhiteSpace(InputModel.Name))
            {
                SystemErrorMessage = "Name is empty.Client validation failed/Bypassed";
                ExposableErrorMessage = "Invalid name";
                return Task.FromResult(false);
            }

            if(InputModel.Name.Length < Settings.NameMinLength)
            {
                SystemErrorMessage = $"Name is too short.Minimum length required is {Settings.NameMinLength}.Client validation failed/Bypassed";
                ExposableErrorMessage = "Invalid  Name";
                return Task.FromResult(false);
            }

            if(InputModel.Name.Length > Settings.NameMaxLength)
            {
                SystemErrorMessage = $"Name is too long.Maximum length allowed is {Settings.NameMaxLength}.Client validation failed/Bypassed";
                ExposableErrorMessage = "Invalid  Name";
                return Task.FromResult(false);
            }
            
            return Task.FromResult(true);
        }
    }
}