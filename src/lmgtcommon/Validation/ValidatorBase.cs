using System.Threading.Tasks;
namespace lmgtcommon.Validation
{
    public abstract class ValidatorBase : ValidationResultBase, IValidator
    {
        public abstract Task<bool> ValidateAsync();
    }
}