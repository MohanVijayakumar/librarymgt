using System.Threading.Tasks;


namespace lmgtdomain.Book.Validator
{
    public class BookNameValidator : BookValidatorBase
    {
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