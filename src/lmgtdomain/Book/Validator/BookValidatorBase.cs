using System;
using System.Threading.Tasks;

using lmgtcommon.Validation;
using lmgtdomain.Book.Model;
using lmgtdomain.Book.Dto;
namespace lmgtdomain.Book.Validator
{
    public abstract class BookValidatorBase : ValidatorBase,IBookValidator
    {
        public BookInputModel InputModel {get;set;}
        public BookSettingsDto Settings {get;set;}
        public abstract override Task<bool> ValidateAsync();        
        
    }
}