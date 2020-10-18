using System.Threading.Tasks;
using System;

using lmgtsecurity.Password.Repository;
using lmgtcommon.Validation;
namespace lmgtsecurity.Password
{
    public class PasswordValidator : ValidationResultBase
    {
        public PasswordValidator(IPasswordSettingsRepository settingsRepository)
        {
            _SettingsRepository = settingsRepository;
        }

        private readonly IPasswordSettingsRepository _SettingsRepository;
        
        public async Task<bool> ValidateAsync(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("password is null");
            }
            var setting = await _SettingsRepository.ByAsync();
            if(password.Length < setting.PasswordMinLength)
            {
                SystemErrorMessage = $"Password length is too short.Minimum Length {setting.PasswordMinLength}.Received length is{password.Length}. Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid password";
                return false;
            }
            if(password.Length > setting.PasswordMaxLength)
            {
                SystemErrorMessage = $"Password length is too long.Maximum Length {setting.PasswordMaxLength}.Received length is{password.Length}. Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid password";
                return false;
            }

            return true;

        }        
    }
}