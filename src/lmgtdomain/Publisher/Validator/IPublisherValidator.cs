using System.Threading.Tasks;

using lmgtdomain.Publisher.Model;
using lmgtdomain.Publisher.Dto;
using lmgtcommon.Validation;
namespace lmgtdomain.Publisher.Validator
{
    public interface IPublisherValidator : IValidator
    {
        PublisherInputModel InputModel {get;set;}
        PublisherSettingsDto Settings {get;set;}
        
    }
}