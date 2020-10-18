using System.Threading.Tasks;

using lmgtdomain.User.Repository;
namespace lmgtdomain.Book.Validator
{
    public class LendBookLendByValidator : LendBookValidatorBase
    {
        public LendBookLendByValidator(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        private readonly IUserRepository _UserRepository;
        public async override Task<bool> ValidateAsync()
        {   
            var lendBy = await _UserRepository.ByAsync(Context.InputModel.LendBy);
            if(lendBy == null)
            {
                SystemErrorMessage = $"The LendBy user not found in database.received user id is {Context.InputModel.LendBy}.Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid LendBy";
                return false;
            }
            return true;
        }
    }
}