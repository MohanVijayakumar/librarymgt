using System.Threading.Tasks;

using lmgtdomain.User.Model;
namespace lmgtdomain.User.Validator
{
    public class EditUserRoleValidator : EditUserValidatorBase
    {
        public EditUserRoleValidator(UserRoleValidator userRoleValidator)
        {
            _UserRoleValidator = userRoleValidator;
        }

        private  UserRoleValidator _UserRoleValidator;

        public async override Task<bool> ValidateAsync()
        {
            _UserRoleValidator.InputModel = new UserInputModel();
            _UserRoleValidator.InputModel.RoleID = InputModel.RoleID;
            _UserRoleValidator.Settings = Settings;

            var res = await _UserRoleValidator.ValidateAsync();
            if(!res)
            {
                CopyResult(_UserRoleValidator);
            }
            return res;
        }
    }
}