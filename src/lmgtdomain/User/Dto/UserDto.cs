using System;
namespace lmgtdomain.User.Dto
{
    public class UserDto
    {
        public int ID {get;set;}
        public string Name {get;set;}
        public string Password {get;set;}
        public short RoleID {get;set;}
        public int CreateBy {get;set;}
        public DateTime CreateTime {get;set;}
    }
}