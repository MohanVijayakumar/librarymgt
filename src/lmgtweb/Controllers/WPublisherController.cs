using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using lmgtdomain.Publisher.Repository;
using lmgtweb.Publisher.Models;
namespace lmgtweb.Controllers
{
    [Authorize(Roles="1")]
    public class WPublisherController : Controller
    {
        public WPublisherController(IPublisherRepository publisherRepository)
        {
            _PublisherRepository = publisherRepository;
        }

        private readonly IPublisherRepository _PublisherRepository;

        [Route("/Publisher/AddPublisherForm")]
        public IActionResult AddAuthorForm()
        {
            return View("views/vpublisher/addpublisherform.cshtml");
        }

        [Route("/Publisher/EditPublisherForm")]
        public async Task<IActionResult> EditPublisherForm(int publisherID)
        {
            EditPublisherFormViewModel vm = new EditPublisherFormViewModel();
            vm.Publisher = await _PublisherRepository.ByAsync(publisherID);
            return View("views/vpublisher/editpublisherform.cshtml",vm);
        }

        [Route("/Publisher/ListPublishers")]
        public async Task<IActionResult> ListAuthors()
        {
            ListPublishersViewModel vm = new ListPublishersViewModel();
            vm.Publishers = await _PublisherRepository.AllAsync();
            return View("views/vpublisher/publisherslist.cshtml",vm);
        }
    }
}
