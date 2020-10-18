using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using lmgtdomain.Book.Repository;
using lmgtweb.Book.Models;
using lmgtdomain.Author.Repository;
using lmgtdomain.Publisher.Repository;
using lmgtdomain.User.Repository;
namespace lmgtweb.Controllers
{  
    public class WBookController : Controller
    {
        public WBookController(IBookCategoryRepository bookCategoryRepository,IAuthorRepository authorRepository,
        IPublisherRepository publisherRepository,IBookSettingsRepository bookSettingsRepository,
        IBookOutputModelRepository bookOutputModelRepository,IUserOutputModelRepository userOutputModelRepository)
        {
            _BookCategoryRepository = bookCategoryRepository;
            _AuthorRepository = authorRepository;
            _PublisherRepository = publisherRepository;
            _BookSettingsRepository = bookSettingsRepository;
            _BookOutputModelRepository = bookOutputModelRepository;
            _UserOutputModelRepository = userOutputModelRepository;
        }
        
        private readonly IBookCategoryRepository _BookCategoryRepository;
        private readonly IAuthorRepository _AuthorRepository;
        private readonly IPublisherRepository _PublisherRepository;
        private readonly IBookSettingsRepository _BookSettingsRepository;
        private readonly IBookOutputModelRepository _BookOutputModelRepository;
        private readonly IUserOutputModelRepository _UserOutputModelRepository;

        [Route("/book/addbookform")]
        public async Task<IActionResult> AddBookForm()
        {
            AddBookFormViewModel vm = new AddBookFormViewModel();
            vm.Authors = await _AuthorRepository.AllAsync();
            vm.Categories = await _BookCategoryRepository.AllAsync();
            vm.Publishers = await _PublisherRepository.AllAsync();
            vm.Settings = await _BookSettingsRepository.ByAsync();            
            return View("views/vbook/addbookform.cshtml",vm);
        }

        [Route("/book/listbooks")]
        public async Task<IActionResult> ListBooks()
        {
            BooksListViewModel vm = new BooksListViewModel();
            vm.Books = await _BookOutputModelRepository.AllAsync();
            vm.Users = await _UserOutputModelRepository.AllAsync();
            return View("views/vbook/bookslist.cshtml",vm);

        }
    }

}