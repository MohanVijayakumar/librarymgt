using System.Threading.Tasks;

using lmgtdomain.User.Model;
namespace lmgtdomain.User.Validator
{
    public class EditUserNameValidator : EditUserValidatorBase
    {
        public EditUserNameValidator(UserNameValidator userNameValidator)
        {
            _UserNameValidator = userNameValidator;
        }

        private  UserNameValidator _UserNameValidator;

        public async override Task<bool> ValidateAsync()
        {
            _UserNameValidator.InputModel = new UserInputModel();
            _UserNameValidator.InputModel.Name = InputModel.Name;
            _UserNameValidator.Settings = Settings;
            var res = await _UserNameValidator.ValidateAsync();
            if(res == false)
            {
                CopyResult(_UserNameValidator);
            }
            return res;
        }
    }
}