using lmgtdomain.Publisher.Dto;
using lmgtdomain.Publisher.Model;
using lmgtcommon;
namespace lmgtdomain.Publisher.Converter
{
    public class ToPublisherDtoConverter
    {
        public PublisherDto Convert(PublisherInputModel inputModel,int creatingUserID)
        {
            var res =new  PublisherDto();
            res.CreateBy = creatingUserID;
            res.CreateTime = TimeUtilities.NowOfApp();
            res.Name = inputModel.Name;

            return res;            
        }

        public PublisherDto Convert(EditPublisherInputModel inputModel)
        {
            var res =new  PublisherDto();
            
            res.Name = inputModel.Name;
            res.ID = inputModel.PublisherID;

            return res;            
        }
    }
}