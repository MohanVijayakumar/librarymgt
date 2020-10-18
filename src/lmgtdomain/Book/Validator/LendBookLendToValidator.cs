using System.Threading.Tasks;

using lmgtdomain.User.Repository;
namespace lmgtdomain.Book.Validator
{
    public class LendBookLendToValidator : LendBookValidatorBase
    {
        public LendBookLendToValidator(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        private readonly IUserRepository _UserRepository;
        public async override Task<bool> ValidateAsync()
        {   
            var lendTo = await _UserRepository.ByAsync(Context.InputModel.LendTo);
            if(lendTo == null)
            {
                SystemErrorMessage = $"The LendTo user not found in database.received user id is {Context.InputModel.LendTo}.Client validation failed/bypassed";
                ExposableErrorMessage = "Invalid LendTo";
                return false;
            }
            return true;
        }
    }
}