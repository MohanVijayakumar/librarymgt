using lmgtdomain.Author.Model;
using lmgtdomain.Author.Dto;
using lmgtcommon;
namespace lmgtdomain.Author.Converter
{
    public class ToAuthorDtoConverter
    {
        public AuthorDto Convert(AuthorInputModel inputModel,int creatingUserID)
        {
            var res = new AuthorDto();
            res.CreateBy = creatingUserID;
            res.CreateTime  = TimeUtilities.NowOfApp();
            res.Name = inputModel.Name;
            

            return res;
        }

        public AuthorDto Convert(EditAuthorInputModel inputModel)
        {
            var res = new AuthorDto();
            res.Name = inputModel.Name;
            res.ID = inputModel.AuthorID;
            return res;
        }
    }   
}