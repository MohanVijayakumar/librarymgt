using System.Collections.Generic;

using lmgtdomain.Book.Model;
using lmgtdomain.User.Model;
namespace lmgtweb.Book.Models
{
    public class BooksListViewModel
    {
        public List<BookOutputModel> Books {get;set;}
        public List<UserOutputModel> Users {get;set;}
    }
}