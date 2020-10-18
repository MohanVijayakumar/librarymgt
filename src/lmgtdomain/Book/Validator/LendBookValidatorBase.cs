using System;
using System.Threading.Tasks;

using lmgtcommon.Validation;
namespace lmgtdomain.Book.Validator
{
    public abstract class LendBookValidatorBase :ValidatorBase,   ILendBookValidator
    {
        public LendBookValidatorBase()
        {
            Context = new LendBookValidatorContext();
        }
        public LendBookValidatorContext Context {get;set;}
        public abstract override Task<bool> ValidateAsync();
        
    }
}