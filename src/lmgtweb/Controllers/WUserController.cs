using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using lmgtdomain.User.Repository;
using lmgtweb.User.Models;
namespace lmgtweb.Controllers
{
    [Authorize(Roles="1")]
    public class WUserController : Controller
    {
        public WUserController(IUserRoleRepository userRoleRepository,IUserOutputModelRepository userOutputModelRepository)
        {
            _UserRoleRepository = userRoleRepository;
            _UserOutputModelRepository = userOutputModelRepository;
        }
        private readonly IUserRoleRepository _UserRoleRepository;
        private readonly IUserOutputModelRepository _UserOutputModelRepository;

        [Route("/User/AddUserForm")]
        public async Task<IActionResult> AddUserForm()
        {
            AddUserFormViewModel vm = new AddUserFormViewModel();
            vm.UserRoles = await _UserRoleRepository.AllAsync();

            return View("views/vuser/adduserform.cshtml",vm);
        }

        [Route("/User/ListUsers")]
        public async Task<IActionResult> UsersList()
        {
            UsersListViewModel vm = new UsersListViewModel();
            vm.Users = await _UserOutputModelRepository.AllAsync();
            return View("views/vuser/userslist.cshtml",vm);
        }

        [Route("/User/EditUserForm")]
        [HttpPost]
        public async Task<IActionResult> EditUserForm(int userID)
        {
            EditUserFormViewModel vm = new EditUserFormViewModel();
            vm.Roles = await _UserRoleRepository.AllAsync();
            vm.User = await _UserOutputModelRepository.ByAsync(userID);
            return View("views/vuser/edituserform.cshtml",vm);
        }
    }
}