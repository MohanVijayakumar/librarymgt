using System.Threading.Tasks;

using lmgtdomain.User.Repository;
namespace lmgtdomain.User.Validator
{
    public class UserRoleValidator : UserValidatorBase
    {
        public UserRoleValidator(IUserRoleRepository userRoleRepository)
        {
            _UserRoleRepository = userRoleRepository;
        }
        private readonly IUserRoleRepository _UserRoleRepository;
        public async override Task<bool> ValidateAsync()
        {
            var uRole = await _UserRoleRepository.ByAsync(InputModel.RoleID);
            if(uRole == null)
            {
                SystemErrorMessage = "User Role not found in database.Client validation failed/Bypassed";
                ExposableErrorMessage = "Invalid UserRole";
                return false;
            }
            return true;
        }
    }
}