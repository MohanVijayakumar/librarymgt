using lmgtdomain.Book.Dto;
using lmgtdomain.Book.Model;
using lmgtcommon;
namespace lmgtdomain.Book.Converter
{
    public class ToBookDtoConverter
    {
        public BookDto Convert(BookInputModel inputModel,int creatingUser)
        {
            var res = new BookDto();
            res.AuthorID = inputModel.AuthodID;
            res.CategoryID = inputModel.CategoryID;
            res.Description = inputModel.Description;
            res.Name = inputModel.Name;
            res.PublisherID = inputModel.PublisherID;
            
            res.CreateBy = creatingUser;
            res.CreateTime = TimeUtilities.NowOfApp();
            res.IsLend = false;

            return res;
        }

        public BookDto Convert(BookEditInputModel inputModel)
        {
            var res = new BookDto();
            res.AuthorID = inputModel.AuthodID;
            res.CategoryID = inputModel.CategoryID;
            res.Description = inputModel.Description;
            res.Name = inputModel.Name;
            res.PublisherID = inputModel.PublisherID;
            res.ID = inputModel.BookID;
            return res;
        }
    }
}