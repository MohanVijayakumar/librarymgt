using lmgtdomain.User.Model;
using lmgtdomain.User.Dto;
using lmgtcommon;
namespace lmgtdomain.User.Converter
{
    public class ToUserDtoConverter
    {
        public UserDto Convert(UserInputModel inputModel,int creatingUserID)
        {   
            var res = new UserDto();
            res.CreateBy = creatingUserID;
            res.CreateTime = TimeUtilities.NowOfApp();
            res.Name = inputModel.Name;
            res.Password = inputModel.Password;
            res.RoleID = inputModel.RoleID;

            return res;

        }

        public UserDto Convert(EditUserInputModel inputModel)
        {
            var res = new UserDto();
            res.Name = inputModel.Name;
            res.RoleID = inputModel.RoleID;
            res.ID = inputModel.UserID;
            return res;
        }
    }
}