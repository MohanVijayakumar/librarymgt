namespace lmgtdomain.Book.Model
{
    public class BookInputModel
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public string TempCoverImagePath {get;set;}
        public string CoverImageFilePath {get;set;}
        public int CategoryID {get;set;}
        public int AuthodID {get;set;}
        public int PublisherID {get;set;}

    }
}