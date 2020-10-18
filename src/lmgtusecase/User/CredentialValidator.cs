using System;
using System.Threading.Tasks;

using lmgtdomain.User.Repository;
using lmgtsecurity.Password;
using lmgtdomain.User.Dto;
namespace lmgtusecase.User
{
    public class CredentialValidator
    {
        public CredentialValidator(IUserRepository userRepository,PasswordHasher passwordHasher)
        {
            _UserRepository = userRepository;
            _PasswordHasher = passwordHasher;
        }

        private readonly IUserRepository _UserRepository;
        private readonly PasswordHasher _PasswordHasher;

        public UserDto User {get;private set;}
        public async Task<bool> ValidateAsync(string userName,string password)
        {
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("UserName is empty");
            }

            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password is empty");
            }

            User = await _UserRepository.ByNameAsync(userName);
            if(User == null)
            {
                return false;
            }

            if(!_PasswordHasher.VerifyHashedPassword(User.Password,password))
            {
                return false;
            }            

            return true;
        }        
    }
}