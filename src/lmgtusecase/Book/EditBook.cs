using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

using lmgtdomain.Book.Model;
using lmgtdomain.Book.Validator;
using lmgtdomain.Book.Repository;
using lmgtcommon.Validation;
using lmgtdomain.Book.Converter;
using lmgtdomain.User.Dto;
namespace lmgtusecase.Book
{
    public class EditBook
    {
        public EditBook(List<IBookValidator> bookValidators,IBookRepository bookRepository,
        IBookSettingsRepository bookSettingsRepository,ToBookDtoConverter toBookDtoConverter,
        CoverImagePathGenerator coverImagePathGenerator)
        {
            _BookValidators = bookValidators;
            _BookRepository = bookRepository;
            _BookSettingsRepository = bookSettingsRepository;
            _ToBookDtoConverter = toBookDtoConverter;
            _CoverImagePathGenerator = coverImagePathGenerator;
        }

        private readonly List<IBookValidator> _BookValidators;
        private readonly IBookRepository _BookRepository;
        private readonly IBookSettingsRepository _BookSettingsRepository;
        private readonly ToBookDtoConverter _ToBookDtoConverter;
        private readonly CoverImagePathGenerator _CoverImagePathGenerator;

        public List<IValidationResult> FailedValidations {get;private set;} 
        public bool DoesBookNameAlreadyExist {get;private set;}

        public async Task<bool> EditAsync(BookEditInputModel inputModel,int creatingUserID,string basePath)
        {
            var bookSetting = await _BookSettingsRepository.ByAsync();
            FailedValidations = new List<IValidationResult>();
            foreach(var bValidator in _BookValidators)
            {
                bValidator.InputModel = inputModel;
                bValidator.Settings  = bookSetting;
                if((await bValidator.ValidateAsync()) == false)
                {
                    FailedValidations.Add(bValidator);
                }
            }

            if(FailedValidations.Count > 0)
            {
                return false;
            }
            
            var dupeNameBook = await _BookRepository.ByNameAsync(inputModel.Name);
            if(dupeNameBook != null)
            {
                DoesBookNameAlreadyExist = true;
                return false;
            }
            
            var book = _ToBookDtoConverter.Convert(inputModel);
            var bBeforeUpdate = await _BookRepository.ByAsync(inputModel.BookID);

            if(string.IsNullOrEmpty(inputModel.TempCoverImagePath))
            {
                book.CoverImagePath = _CoverImagePathGenerator.Generate(basePath,book.ID,Path.GetExtension(inputModel.TempCoverImagePath));
                
            }
            else
            {
                book.CoverImagePath = bBeforeUpdate.CoverImagePath;
            }

            await _BookRepository.UpdateAsync(book);
            
            return true;
        }
    }
}
