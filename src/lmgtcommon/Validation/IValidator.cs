using System.Threading.Tasks;
namespace lmgtcommon.Validation
{
    public interface IValidator : IValidationResult
    {
        
        /// <summary>
        /// Main validation
        /// </summary>
        /// <returns>True if the validation passed successfully passed. Else returns false</returns>
        Task<bool> ValidateAsync();
    }
}