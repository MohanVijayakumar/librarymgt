using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.User.Model;
using lmgtdomain.User.Repository;
using lmgtdomain.User.Validator;
using lmgtdomain.User.Dto;
using lmgtdomain.User.Converter;
using lmgtcommon.Validation;
using lmgtsecurity.Password;
namespace lmgtusecase.User
{
    public class AddNewUser
    {
        public AddNewUser(List<IUserValidator> userValidators,IUserRepository userRepository,
        ToUserDtoConverter toUserDtoConverter,IUserSettingsRepository settingsRepository,
        PasswordValidator passwordValidator,PasswordHasher passwordHasher)
        {
            _UserValidators = userValidators;
            _UserRepository = userRepository;
            _ToUserDtoConverter = toUserDtoConverter;
            _SettingsRepository = settingsRepository;
            _PasswordValidator = passwordValidator;
            _PasswordHasher = passwordHasher;
        }

        private readonly List<IUserValidator> _UserValidators;
        private readonly IUserRepository _UserRepository;
        private readonly ToUserDtoConverter _ToUserDtoConverter;
        private readonly IUserSettingsRepository _SettingsRepository;
        private readonly PasswordValidator _PasswordValidator;
        private readonly PasswordHasher _PasswordHasher;

        public List<IValidationResult> FailedValidations {get;private set;}
        public bool DoesNameAlreadyExist {get;private set;}
        public async Task<bool> AddAsync(UserInputModel inputModel,int creatingUserID)
        {
            FailedValidations = new List<IValidationResult>();
            var setting = await _SettingsRepository.ByAsync();
            foreach(var uValidator in _UserValidators)
            {
                uValidator.InputModel = inputModel;
                uValidator.Settings = setting;
                if (!(await uValidator.ValidateAsync()))
                {
                    FailedValidations.Add(uValidator);
                }                
            }

            if(FailedValidations.Count > 0)
            {
                return false;
            }
            
            var dupeUserByName = await _UserRepository.ByNameAsync(inputModel.Name);
            if(dupeUserByName != null)
            {
                DoesNameAlreadyExist = true;
                return false;
            }

            if(!(await _PasswordValidator.ValidateAsync(inputModel.Password)))
            {
                FailedValidations.Add(_PasswordValidator);
                return false;
            }

            var user = _ToUserDtoConverter.Convert(inputModel,creatingUserID);
            user.Password = _PasswordHasher.HashPassword(inputModel.Password);
            await _UserRepository.AddAsync(user);
            return true;
        }
    }

}