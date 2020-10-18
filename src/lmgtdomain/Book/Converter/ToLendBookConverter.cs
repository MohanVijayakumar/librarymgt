using lmgtdomain.Book.Dto;
using lmgtdomain.Book.Model;
using lmgtcommon;
namespace lmgtdomain.Book.Converter
{
    public class ToLendBookConverter
    {
        public LendBookDto Convert(LendBookInputModel inputModel)
        {
            LendBookDto res = new LendBookDto();
            res.BookID = inputModel.BookID;
            res.LendBy = inputModel.LendBy;
            res.LendOn = TimeUtilities.NowOfApp();
            res.LendTo = inputModel.LendTo;
            return res;
        }
    }
}