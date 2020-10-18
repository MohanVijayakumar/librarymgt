using System.Threading.Tasks;

using lmgtcommon.Validation;
using lmgtdomain.Publisher.Model;
using lmgtdomain.Publisher.Dto;
namespace lmgtdomain.Publisher.Validator
{
    public class PublisherNameValidator : ValidatorBase , IPublisherValidator
    {
        public PublisherInputModel InputModel {get;set;}
        public PublisherSettingsDto Settings {get;set;}
        public override Task<bool> ValidateAsync()
        {
            if(string.IsNullOrEmpty(InputModel.Name))
            {
                SystemErrorMessage = "Name is null.Client validation failed/bypassed";
                ExposableErrorMessage ="Name is empty";
                return Task.FromResult(false);
            }
            if(InputModel.Name.Length < Settings.NameMinLength)
            {
                SystemErrorMessage = $"Name length is too short.Minimum Required {Settings.NameMinLength}. Received {InputModel.Name.Length}.Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid Name";
                return Task.FromResult(false);
            }

            if(InputModel.Name.Length > Settings.NameMaxLength)
            {
                SystemErrorMessage = $"Name length is too long.Maximum Allowed {Settings.NameMaxLength}. Received {InputModel.Name.Length}.Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid Name";
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}