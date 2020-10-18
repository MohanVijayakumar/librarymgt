using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace lmgtweb.Controllers
{
    
    public class EntryController : Controller
    {
        [Route("Login")]
        public IActionResult Login()
        {
            return View("Views/Entry/Login.cshtml");
        }

        [Authorize]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View("views/entry/login.cshtml");
        }
    }
}