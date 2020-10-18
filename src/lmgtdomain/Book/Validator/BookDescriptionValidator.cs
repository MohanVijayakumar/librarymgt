using System.Threading.Tasks;


namespace lmgtdomain.Book.Validator
{
    public class BookDescriptionValidator : BookValidatorBase
    {
        public  override Task<bool> ValidateAsync()
        {
            
            if(string.IsNullOrWhiteSpace(InputModel.Description))
            {
                SystemErrorMessage = "Description is empty.Client validation failed/Bypassed";
                ExposableErrorMessage = "Description is empty";
                return Task.FromResult(false);
            }

            if(InputModel.Description.Length < Settings.DescriptionMinLength)
            {
                SystemErrorMessage = $"Length of Description is too short.Minimum length required is {Settings.DescriptionMinLength}.Client validation Failed/Bypassed";
                ExposableErrorMessage = "Invalid Name";
                return Task.FromResult(false);
            }

            if(InputModel.Description.Length > Settings.DescriptionMaxLength)
            {
                SystemErrorMessage = $"Length of Description is too long.Maximum length is {Settings.DescriptionMaxLength}.Client validation Failed/Bypassed";
                ExposableErrorMessage = "Invalid Description";
                return Task.FromResult(false);
            }
            
            return Task.FromResult(true);
        }
    }
}