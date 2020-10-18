using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.User.Model;
using lmgtdomain.User.Repository;
using lmgtdomain.User.Validator;
using lmgtdomain.User.Dto;
using lmgtdomain.User.Converter;
using lmgtcommon.Validation;


namespace lmgtusecase.User
{
    public class EditUser
    {
        public EditUser(List<IEditUserValidator> userValidators,IUserRepository userRepository,
        ToUserDtoConverter toUserDtoConverter,IUserSettingsRepository settingsRepository)
        {
            _UserValidators = userValidators;
            _UserRepository = userRepository;
            _ToUserDtoConverter = toUserDtoConverter;
            _SettingsRepository = settingsRepository;
        }

        private readonly List<IEditUserValidator> _UserValidators;
        private readonly IUserRepository _UserRepository;
        private readonly ToUserDtoConverter _ToUserDtoConverter;
        private readonly IUserSettingsRepository _SettingsRepository; 

        public List<IValidationResult> FailedValidations {get;private set;}
        public bool DoesNameAlreadyExist {get;private set;}

        public async Task<bool> EditAsync(EditUserInputModel inputModel)
        {
            FailedValidations = new List<IValidationResult>();
            var setting = await _SettingsRepository.ByAsync();
            foreach(var uValidator in _UserValidators)
            {
                uValidator.InputModel = inputModel;
                uValidator.Settings = setting;
                if(!(await uValidator.ValidateAsync()))
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

            var countUpdate = await _UserRepository.UpdateAtEditAsync(_ToUserDtoConverter.Convert(inputModel));
            return true;
        }
    }

}