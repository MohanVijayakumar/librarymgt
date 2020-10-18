using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Book.Repository;
using lmgtdomain.Book.Model;
using lmgtdomain.Book.Validator;
using lmgtcommon.Validation;
using lmgtdomain.Book.Converter;
using lmgtdomain.User.Dto;
namespace lmgtusecase.Book
{
    public class LendBook
    {
        public LendBook(List<ILendBookValidator> lendBookValidators,ILendBookRepository lendBookRepository,
        ToLendBookConverter toLendBookConverter,IBookRepository bookRepository)
        {   
            _LendBookValidators = lendBookValidators;
            _LendBookRepository = lendBookRepository;
            _ToLendBookConverter= toLendBookConverter;
            _BookRepository = bookRepository;
        }
        private List<ILendBookValidator> _LendBookValidators;
        private readonly ILendBookRepository _LendBookRepository;
        private readonly ToLendBookConverter _ToLendBookConverter;
        private readonly IBookRepository _BookRepository;
        private List<IValidationResult> FailedValidations;
        public bool IsBookLend {get ;private set;}
        public async Task<bool> LendAsync(LendBookInputModel inputModel,int creatingUserID)
        {
            inputModel.LendBy = creatingUserID;
            FailedValidations = new List<IValidationResult>();
            LendBookValidatorContext validatorContext = new LendBookValidatorContext();
            validatorContext.InputModel = inputModel;
            foreach(var lBValidator in _LendBookValidators)
            {
                lBValidator.Context = validatorContext;
                if(!(await lBValidator.ValidateAsync()))
                {
                    FailedValidations.Add(lBValidator);
                }
            }

            if(FailedValidations.Count > 0)
            {
                return false;
            }

            var book = validatorContext.BookToBeLend;
            if(book.IsLend)
            {
                IsBookLend = true;
                return false;
            }   
            
            var countUpdate = await _BookRepository.UpdateLendAsync(book);
            if(countUpdate != 1)
            {
                throw new Exception($"While updating the method _BookRepository.UpdateLendAsync returned {countUpdate} instread of 1.BookID is{book.ID}");
            }
            var lBook = _ToLendBookConverter.Convert(inputModel);
            await _LendBookRepository.AddAsync(lBook);
            return true;
        }
    }
}