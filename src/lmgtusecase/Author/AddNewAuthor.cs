using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Author.Repository;
using lmgtdomain.Author.Validator;
using lmgtdomain.Author.Model;
using lmgtcommon.Validation;
using lmgtdomain.Author.Converter;
using lmgtdomain.User.Dto;
namespace lmgtusecase.Author
{
    public class AddNewAuthor
    {
        public AddNewAuthor(List<IAuthorValidator> authorValidators,IAuthorRepository authorRepository,
        IAuthorSettingsRepository authorSettingsRepository,ToAuthorDtoConverter toAuthorDtoConverter)
        {
            _AuthorValidators = authorValidators;
            _AuthorRepository = authorRepository;
            _SettingsRepository = authorSettingsRepository;
            _ToAuthorDtoConverter = toAuthorDtoConverter;
        }

        private readonly List<IAuthorValidator> _AuthorValidators;
        private readonly IAuthorRepository _AuthorRepository;
        private readonly IAuthorSettingsRepository _SettingsRepository;
        private readonly ToAuthorDtoConverter _ToAuthorDtoConverter;

        public List<IValidationResult> FailedValidations {get;private set;}

        public bool DoesNameAlreadyExist {get;private set;}
        public async Task<bool> AddAsync(AuthorInputModel inputModel,int creatingUserID)
        {
            FailedValidations = new List<IValidationResult>();
            var setting = await _SettingsRepository.ByAsync();
            foreach(var aValidator in _AuthorValidators)
            {
                aValidator.Settings = setting;
                aValidator.InputModel = inputModel;
                if(!(await aValidator.ValidateAsync()))
                {
                    FailedValidations.Add(aValidator);
                }

            }
            if(FailedValidations.Count > 0)
            {
                return false;
            }
            var dupeNameAuthor = await _AuthorRepository.ByNameAsync(inputModel.Name);
            if(dupeNameAuthor != null)
            {
                DoesNameAlreadyExist = true;
                return false;
            }
            
            await _AuthorRepository.AddAsync(_ToAuthorDtoConverter.Convert(inputModel,creatingUserID));

            return true;
        }
    }
}