using System.Collections.Generic;

using lmgtdomain.Book.Dto;
using lmgtdomain.Author.Dto;
using lmgtdomain.Publisher.Dto;
namespace lmgtweb.Book.Models
{
    public class AddBookFormViewModel
    {
        public List<BookCategoryDto> Categories {get;set;}
        public List<AuthorDto> Authors {get;set;}
        public List<PublisherDto> Publishers {get;set;}
        public BookSettingsDto Settings {get;set;}
    }
}