using Microsoft.AspNetCore.Http;
namespace lmgtweb.Book.Models
{
    public class AddBookInputModel
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public IFormFile CoverImageFile {get;set;}
        public int CategoryID {get;set;}
        public int AuthodID {get;set;}
        public int PublisherID {get;set;}
    }
}