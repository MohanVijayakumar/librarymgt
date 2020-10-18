namespace lmgtdomain.Book.Model
{
    public class BookOutputModel
    {
        public int ID {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string AuthorName {get;set;}
        public int AuthorID {get;set;}
        public string PublisherName {get;set;}
        public int PublisherID {get;set;}
        public string CategoryName {get;set;}
        public int CategoryID {get;set;}        
        public string CoverImagePublicPath {get;set;}
        public bool IsLend {get;set;}
    }
}