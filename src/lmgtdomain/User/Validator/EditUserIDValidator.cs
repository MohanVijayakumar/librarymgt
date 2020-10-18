using System.Threading.Tasks;

using lmgtdomain.User.Repository;
namespace lmgtdomain.User.Validator
{
    public class EditUserIDValidator : EditUserValidatorBase
    {
        public EditUserIDValidator(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        private readonly IUserRepository _UserRepository;
        public async override Task<bool> ValidateAsync()
        {
            var user = await _UserRepository.ByAsync(InputModel.UserID);
            if(user == null)
            {
                SystemErrorMessage = "UserID not found in database.Received UserID is {}.Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid User";
                return false;
            }

            return true;
        }

    }
}