using System;
namespace lmgtdomain.Book.Dto
{
    public class BookDto
    {
        public int ID {get;set;}
        public string Name {get;set;}    
        public string CoverImagePath {get;set;}
        public int CategoryID {get;set;}
        public int AuthorID {get;set;}
        public int PublisherID {get;set;}
        public string Description {get;set;}
        public bool IsLend {get;set;}
        public int CreateBy {get;set;}
        public DateTime CreateTime {get;set;}
        
    }
}
    

