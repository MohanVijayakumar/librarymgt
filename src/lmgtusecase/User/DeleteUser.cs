using System.Threading.Tasks;

using lmgtdomain.User.Repository;
namespace lmgtusecase.User
{
    public class DeleteUser
    {
        public DeleteUser(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        private readonly IUserRepository _UserRepository;

        public async Task<bool> DeleteAsync(int userID)
        {
            var countDelete = await _UserRepository.DeleteAsync(userID);
            return countDelete ==1;
        }
    }
}