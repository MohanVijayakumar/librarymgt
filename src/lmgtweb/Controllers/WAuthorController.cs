using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using lmgtdomain.Author.Repository;
using lmgtweb.Author.Models;
namespace lmgtweb.Controllers
{
    [Authorize(Roles="1")]
    public class WAuthorController : Controller
    {
        public WAuthorController(IAuthorRepository authorRepository)
        {
            _AuthorRepository = authorRepository;
        }

        private readonly IAuthorRepository _AuthorRepository;

        [Route("/Author/AddAuthorForm")]
        public IActionResult AddAuthorForm()
        {
            return View("views/vauthor/addauthorform.cshtml");
        }

        [Route("/Author/EditAuthorForm")]
        public async Task<IActionResult> EditAuthorForm(int authorID)
        {
            EditAuthorFormViewModel vm = new EditAuthorFormViewModel();
            vm.Author = await _AuthorRepository.ByAsync(authorID);
            return View("views/vauthor/editauthorform.cshtml",vm);
        }

        [Route("/Author/ListAuthors")]
        public async Task<IActionResult> ListAuthors()
        {
            ListAuthorsViewModel vm = new ListAuthorsViewModel();
            vm.Authors = await _AuthorRepository.AllAsync();
            return View("views/vauthor/authorslist.cshtml",vm);
        }
    }
}
