namespace lmgtdomain.Book.Model
{
    public class BookEditInputModel : BookInputModel
    {
        public int BookID {get;set;}
        public bool IsOldCoverFileDeleted {get;set;}
    }
}