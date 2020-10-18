using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Publisher.Repository;
using lmgtdomain.Publisher.Model;
using lmgtcommon.Validation;
using lmgtdomain.Publisher.Converter;
using lmgtdomain.User.Dto;
using lmgtdomain.Publisher.Validator;
namespace lmgtusecase.Publisher
{
    public class AddNewPublisher
    {
        public AddNewPublisher(List<IPublisherValidator> publisherValidators,IPublisherRepository publisherRepository,
        IPublishSettingsRepository settingsRepository,ToPublisherDtoConverter toPublisherDtoConverter)
        {
            _PublisherRepository = publisherRepository;
            _PublisherValidators = publisherValidators;
            _ToPublisherDtoConverter = toPublisherDtoConverter;
            _SettingsRepository = settingsRepository;
        }

        private readonly List<IPublisherValidator> _PublisherValidators;
        private readonly IPublisherRepository _PublisherRepository;
        private readonly IPublishSettingsRepository _SettingsRepository;
        private readonly ToPublisherDtoConverter _ToPublisherDtoConverter;

        public List<IValidationResult> FailedValidations {get;private set;}

        public bool DoesNameAlreadyExist {get;private set;}
        public async Task<bool> AddAsync(PublisherInputModel inputModel,int creatingUserID)
        {
            FailedValidations = new List<IValidationResult>();
            var setting = await _SettingsRepository.ByAsync();
            foreach(var pValidator in _PublisherValidators)
            {
                pValidator.Settings = setting;
                pValidator.InputModel = inputModel;
                if(!(await pValidator.ValidateAsync()))
                {
                    FailedValidations.Add(pValidator);
                }

            }
            if(FailedValidations.Count > 0)
            {
                return false;
            }
            var dupeNameAuthor = await _PublisherRepository.ByNameAsync(inputModel.Name);
            if(dupeNameAuthor != null)
            {
                DoesNameAlreadyExist = true;
                return false;
            }
            
            await _PublisherRepository.AddAsync(_ToPublisherDtoConverter.Convert(inputModel,creatingUserID));

            return true;
        }
    }
}