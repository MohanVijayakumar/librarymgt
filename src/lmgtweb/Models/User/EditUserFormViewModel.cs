using System.Collections.Generic;

using lmgtdomain.User.Model;
using lmgtdomain.User.Dto;
namespace lmgtweb.User.Models
{
    public class EditUserFormViewModel
    {
        public UserOutputModel User {get;set;}
        public List<UserRoleDto> Roles {get;set;}
    }
}