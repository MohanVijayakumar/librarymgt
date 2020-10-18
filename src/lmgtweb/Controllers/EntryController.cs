using Microsoft.AspNetCore.Mvc;
namespace lmgtweb.Controllers
{
    
    public class EntryController : Controller
    {
        [Route("Login")]
        public IActionResult Login()
        {
            return View("Views/Entry/Login.cshtml");
        }
    }
}