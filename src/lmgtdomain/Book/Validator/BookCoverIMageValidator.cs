using System.Threading.Tasks;
using System.Linq;
using System.IO;
namespace lmgtdomain.Book.Validator
{
    public class BookCoverImageValidator : BookValidatorBase
    {
        public override Task<bool> ValidateAsync()
        {
            if(string.IsNullOrEmpty(InputModel.CoverImageFilePath))
            {
                return Task.FromResult(true);
            }
            var allowedExtentions = Settings.CoverImageAllowedFormats.Split(',');
            var extension =  Path.GetExtension( InputModel.CoverImageFilePath.ToLower()).Replace(".","");
            
            if(allowedExtentions.SingleOrDefault(s=> s.ToLower() == extension ) == null )
            {
                SystemErrorMessage = $"Invalid image format.Received format is {extension}.Client validation Failed/Bypassed";
                ExposableErrorMessage = "Invalid Image Format";
                return Task.FromResult(false);
            }

            var fSize = new FileInfo(InputModel.CoverImageFilePath).Length;
            if(fSize > Settings.CoverImageMaxSizeInBytes)
            {
                SystemErrorMessage = $"File Size is huge.Maximum File Size in bytes is {Settings.CoverImageMaxSizeInBytes}.Client validation Failed/Bypassed";
                ExposableErrorMessage = "Big File";
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
